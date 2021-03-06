using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractTeacherSkillMapper
	{
		public virtual BOTeacherSkill MapModelToBO(
			int id,
			ApiTeacherSkillRequestModel model
			)
		{
			BOTeacherSkill boTeacherSkill = new BOTeacherSkill();
			boTeacherSkill.SetProperties(
				id,
				model.Name,
				model.StudioId);
			return boTeacherSkill;
		}

		public virtual ApiTeacherSkillResponseModel MapBOToModel(
			BOTeacherSkill boTeacherSkill)
		{
			var model = new ApiTeacherSkillResponseModel();

			model.SetProperties(boTeacherSkill.Id, boTeacherSkill.Name, boTeacherSkill.StudioId);

			return model;
		}

		public virtual List<ApiTeacherSkillResponseModel> MapBOToModel(
			List<BOTeacherSkill> items)
		{
			List<ApiTeacherSkillResponseModel> response = new List<ApiTeacherSkillResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ea0990dac51840c1db045441e1eddd6d</Hash>
</Codenesium>*/