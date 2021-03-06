using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractLibraryVariableSetService : AbstractService
	{
		private ILibraryVariableSetRepository libraryVariableSetRepository;

		private IApiLibraryVariableSetRequestModelValidator libraryVariableSetModelValidator;

		private IBOLLibraryVariableSetMapper bolLibraryVariableSetMapper;

		private IDALLibraryVariableSetMapper dalLibraryVariableSetMapper;

		private ILogger logger;

		public AbstractLibraryVariableSetService(
			ILogger logger,
			ILibraryVariableSetRepository libraryVariableSetRepository,
			IApiLibraryVariableSetRequestModelValidator libraryVariableSetModelValidator,
			IBOLLibraryVariableSetMapper bolLibraryVariableSetMapper,
			IDALLibraryVariableSetMapper dalLibraryVariableSetMapper)
			: base()
		{
			this.libraryVariableSetRepository = libraryVariableSetRepository;
			this.libraryVariableSetModelValidator = libraryVariableSetModelValidator;
			this.bolLibraryVariableSetMapper = bolLibraryVariableSetMapper;
			this.dalLibraryVariableSetMapper = dalLibraryVariableSetMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLibraryVariableSetResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.libraryVariableSetRepository.All(limit, offset);

			return this.bolLibraryVariableSetMapper.MapBOToModel(this.dalLibraryVariableSetMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLibraryVariableSetResponseModel> Get(string id)
		{
			var record = await this.libraryVariableSetRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolLibraryVariableSetMapper.MapBOToModel(this.dalLibraryVariableSetMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLibraryVariableSetResponseModel>> Create(
			ApiLibraryVariableSetRequestModel model)
		{
			CreateResponse<ApiLibraryVariableSetResponseModel> response = new CreateResponse<ApiLibraryVariableSetResponseModel>(await this.libraryVariableSetModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolLibraryVariableSetMapper.MapModelToBO(default(string), model);
				var record = await this.libraryVariableSetRepository.Create(this.dalLibraryVariableSetMapper.MapBOToEF(bo));

				response.SetRecord(this.bolLibraryVariableSetMapper.MapBOToModel(this.dalLibraryVariableSetMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLibraryVariableSetResponseModel>> Update(
			string id,
			ApiLibraryVariableSetRequestModel model)
		{
			var validationResult = await this.libraryVariableSetModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolLibraryVariableSetMapper.MapModelToBO(id, model);
				await this.libraryVariableSetRepository.Update(this.dalLibraryVariableSetMapper.MapBOToEF(bo));

				var record = await this.libraryVariableSetRepository.Get(id);

				return new UpdateResponse<ApiLibraryVariableSetResponseModel>(this.bolLibraryVariableSetMapper.MapBOToModel(this.dalLibraryVariableSetMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiLibraryVariableSetResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.libraryVariableSetModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.libraryVariableSetRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiLibraryVariableSetResponseModel> ByName(string name)
		{
			LibraryVariableSet record = await this.libraryVariableSetRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolLibraryVariableSetMapper.MapBOToModel(this.dalLibraryVariableSetMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>a1fc01337029ac194e19538db3ae51ad</Hash>
</Codenesium>*/