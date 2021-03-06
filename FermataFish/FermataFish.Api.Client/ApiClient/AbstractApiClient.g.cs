using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Client
{
	public abstract class AbstractApiClient
	{
		private HttpClient client;

		protected string ApiUrl { get; set; }

		protected string ApiVersion { get; set; }

		public AbstractApiClient(HttpClient client)
		{
			this.client = client;
		}

		public AbstractApiClient(string apiUrl, string apiVersion)
		{
			if (string.IsNullOrWhiteSpace(apiUrl))
			{
				throw new ArgumentException("apiUrl is not set");
			}

			if (string.IsNullOrWhiteSpace(apiVersion))
			{
				throw new ArgumentException("apiVersion is not set");
			}

			if (!apiUrl.EndsWith("/"))
			{
				apiUrl += "/";
			}

			this.ApiUrl = apiUrl;
			this.ApiVersion = apiVersion;
			this.client = new HttpClient();
			this.client.BaseAddress = new Uri(apiUrl);
			this.client.DefaultRequestHeaders.Accept.Clear();
			this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			this.client.DefaultRequestHeaders.Add("api-version", this.ApiVersion);
		}

		public void SetBearerToken(string token)
		{
			this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		}

		public virtual async Task<CreateResponse<ApiAdminResponseModel>> AdminCreateAsync(ApiAdminRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Admins", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiAdminResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiAdminResponseModel>> AdminUpdateAsync(int id, ApiAdminRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Admins/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiAdminResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> AdminDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Admins/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiAdminResponseModel> AdminGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Admins/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiAdminResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAdminResponseModel>> AdminAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Admins?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAdminResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAdminResponseModel>> AdminBulkInsertAsync(List<ApiAdminRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Admins/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAdminResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiFamilyResponseModel>> FamilyCreateAsync(ApiFamilyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Families", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiFamilyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiFamilyResponseModel>> FamilyUpdateAsync(int id, ApiFamilyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Families/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiFamilyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> FamilyDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Families/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiFamilyResponseModel> FamilyGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Families/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiFamilyResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiFamilyResponseModel>> FamilyAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Families?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiFamilyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiFamilyResponseModel>> FamilyBulkInsertAsync(List<ApiFamilyRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Families/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiFamilyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStudentResponseModel>> Students(int familyId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Families/Students/{familyId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStudentXFamilyResponseModel>> StudentXFamilies(int familyId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Families/StudentXFamilies/{familyId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStudentXFamilyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiLessonResponseModel>> LessonCreateAsync(ApiLessonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Lessons", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiLessonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiLessonResponseModel>> LessonUpdateAsync(int id, ApiLessonRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Lessons/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiLessonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> LessonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Lessons/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLessonResponseModel> LessonGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lessons/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLessonResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLessonResponseModel>> LessonAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lessons?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLessonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLessonResponseModel>> LessonBulkInsertAsync(List<ApiLessonRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Lessons/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLessonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLessonXStudentResponseModel>> LessonXStudents(int lessonId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lessons/LessonXStudents/{lessonId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLessonXStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLessonXTeacherResponseModel>> LessonXTeachers(int lessonId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lessons/LessonXTeachers/{lessonId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLessonXTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiLessonStatusResponseModel>> LessonStatusCreateAsync(ApiLessonStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonStatus", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiLessonStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiLessonStatusResponseModel>> LessonStatusUpdateAsync(int id, ApiLessonStatusRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LessonStatus/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiLessonStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> LessonStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LessonStatus/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLessonStatusResponseModel> LessonStatusGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonStatus/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLessonStatusResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLessonStatusResponseModel>> LessonStatusAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonStatus?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLessonStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLessonStatusResponseModel>> LessonStatusBulkInsertAsync(List<ApiLessonStatusRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonStatus/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLessonStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLessonResponseModel>> Lessons(int lessonStatusId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonStatus/Lessons/{lessonStatusId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLessonResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiLessonXStudentResponseModel>> LessonXStudentCreateAsync(ApiLessonXStudentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonXStudents", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiLessonXStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiLessonXStudentResponseModel>> LessonXStudentUpdateAsync(int id, ApiLessonXStudentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LessonXStudents/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiLessonXStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> LessonXStudentDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LessonXStudents/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLessonXStudentResponseModel> LessonXStudentGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonXStudents/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLessonXStudentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLessonXStudentResponseModel>> LessonXStudentAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonXStudents?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLessonXStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLessonXStudentResponseModel>> LessonXStudentBulkInsertAsync(List<ApiLessonXStudentRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonXStudents/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLessonXStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiLessonXTeacherResponseModel>> LessonXTeacherCreateAsync(ApiLessonXTeacherRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonXTeachers", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiLessonXTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiLessonXTeacherResponseModel>> LessonXTeacherUpdateAsync(int id, ApiLessonXTeacherRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LessonXTeachers/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiLessonXTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> LessonXTeacherDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LessonXTeachers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLessonXTeacherResponseModel> LessonXTeacherGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonXTeachers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLessonXTeacherResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLessonXTeacherResponseModel>> LessonXTeacherAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonXTeachers?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLessonXTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLessonXTeacherResponseModel>> LessonXTeacherBulkInsertAsync(List<ApiLessonXTeacherRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonXTeachers/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLessonXTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiRateResponseModel>> RateCreateAsync(ApiRateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Rates", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiRateResponseModel>> RateUpdateAsync(int id, ApiRateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Rates/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> RateDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Rates/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiRateResponseModel> RateGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Rates/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiRateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiRateResponseModel>> RateAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Rates?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiRateResponseModel>> RateBulkInsertAsync(List<ApiRateRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Rates/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSpaceResponseModel>> SpaceCreateAsync(ApiSpaceRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Spaces", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSpaceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSpaceResponseModel>> SpaceUpdateAsync(int id, ApiSpaceRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Spaces/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSpaceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SpaceDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Spaces/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSpaceResponseModel> SpaceGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Spaces/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSpaceResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpaceResponseModel>> SpaceAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Spaces?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpaceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpaceResponseModel>> SpaceBulkInsertAsync(List<ApiSpaceRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Spaces/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpaceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatures(int spaceId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Spaces/SpaceXSpaceFeatures/{spaceId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpaceXSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSpaceFeatureResponseModel>> SpaceFeatureCreateAsync(ApiSpaceFeatureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceFeatures", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSpaceFeatureResponseModel>> SpaceFeatureUpdateAsync(int id, ApiSpaceFeatureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SpaceFeatures/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SpaceFeatureDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SpaceFeatures/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSpaceFeatureResponseModel> SpaceFeatureGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceFeatures/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSpaceFeatureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpaceFeatureResponseModel>> SpaceFeatureAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceFeatures?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpaceFeatureResponseModel>> SpaceFeatureBulkInsertAsync(List<ApiSpaceFeatureRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceFeatures/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatureCreateAsync(ApiSpaceXSpaceFeatureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceXSpaceFeatures", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiSpaceXSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatureUpdateAsync(int id, ApiSpaceXSpaceFeatureRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SpaceXSpaceFeatures/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> SpaceXSpaceFeatureDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SpaceXSpaceFeatures/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiSpaceXSpaceFeatureResponseModel> SpaceXSpaceFeatureGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceXSpaceFeatures/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiSpaceXSpaceFeatureResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatureAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceXSpaceFeatures?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpaceXSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatureBulkInsertAsync(List<ApiSpaceXSpaceFeatureRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceXSpaceFeatures/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpaceXSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiStateResponseModel>> StateCreateAsync(ApiStateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/States", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiStateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiStateResponseModel>> StateUpdateAsync(int id, ApiStateRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/States/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiStateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> StateDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/States/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiStateResponseModel> StateGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/States/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiStateResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStateResponseModel>> StateAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/States?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStateResponseModel>> StateBulkInsertAsync(List<ApiStateRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/States/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStudioResponseModel>> Studios(int stateId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/States/Studios/{stateId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStudioResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiStudentResponseModel>> StudentCreateAsync(ApiStudentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Students", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiStudentResponseModel>> StudentUpdateAsync(int id, ApiStudentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Students/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> StudentDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Students/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiStudentResponseModel> StudentGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Students/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiStudentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStudentResponseModel>> StudentAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Students?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStudentResponseModel>> StudentBulkInsertAsync(List<ApiStudentRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Students/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStudentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiStudentXFamilyResponseModel>> StudentXFamilyCreateAsync(ApiStudentXFamilyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/StudentXFamilies", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiStudentXFamilyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiStudentXFamilyResponseModel>> StudentXFamilyUpdateAsync(int id, ApiStudentXFamilyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/StudentXFamilies/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiStudentXFamilyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> StudentXFamilyDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/StudentXFamilies/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiStudentXFamilyResponseModel> StudentXFamilyGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StudentXFamilies/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiStudentXFamilyResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStudentXFamilyResponseModel>> StudentXFamilyAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StudentXFamilies?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStudentXFamilyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStudentXFamilyResponseModel>> StudentXFamilyBulkInsertAsync(List<ApiStudentXFamilyRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/StudentXFamilies/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStudentXFamilyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiStudioResponseModel>> StudioCreateAsync(ApiStudioRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Studios", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiStudioResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiStudioResponseModel>> StudioUpdateAsync(int id, ApiStudioRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Studios/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiStudioResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> StudioDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Studios/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiStudioResponseModel> StudioGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiStudioResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStudioResponseModel>> StudioAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStudioResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiStudioResponseModel>> StudioBulkInsertAsync(List<ApiStudioRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Studios/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiStudioResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiAdminResponseModel>> Admins(int studioId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios/Admins/{studioId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiAdminResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiFamilyResponseModel>> Families(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios/Families/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiFamilyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLessonStatusResponseModel>> LessonStatus(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios/LessonStatus/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLessonStatusResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpaceResponseModel>> Spaces(int studioId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios/Spaces/{studioId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpaceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiSpaceFeatureResponseModel>> SpaceFeatures(int studioId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios/SpaceFeatures/{studioId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiSpaceFeatureResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeacherResponseModel>> Teachers(int studioId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios/Teachers/{studioId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeacherSkillResponseModel>> TeacherSkills(int studioId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios/TeacherSkills/{studioId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTeacherResponseModel>> TeacherCreateAsync(ApiTeacherRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teachers", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTeacherResponseModel>> TeacherUpdateAsync(int id, ApiTeacherRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Teachers/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TeacherDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Teachers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTeacherResponseModel> TeacherGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teachers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTeacherResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeacherResponseModel>> TeacherAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teachers?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeacherResponseModel>> TeacherBulkInsertAsync(List<ApiTeacherRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teachers/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeacherResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiRateResponseModel>> Rates(int teacherId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teachers/Rates/{teacherId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiRateResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeacherXTeacherSkillResponseModel>> TeacherXTeacherSkills(int teacherId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teachers/TeacherXTeacherSkills/{teacherId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeacherXTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTeacherSkillResponseModel>> TeacherSkillCreateAsync(ApiTeacherSkillRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherSkills", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTeacherSkillResponseModel>> TeacherSkillUpdateAsync(int id, ApiTeacherSkillRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TeacherSkills/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TeacherSkillDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TeacherSkills/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTeacherSkillResponseModel> TeacherSkillGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherSkills/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTeacherSkillResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeacherSkillResponseModel>> TeacherSkillAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherSkills?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeacherSkillResponseModel>> TeacherSkillBulkInsertAsync(List<ApiTeacherSkillRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherSkills/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTeacherXTeacherSkillResponseModel>> TeacherXTeacherSkillCreateAsync(ApiTeacherXTeacherSkillRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherXTeacherSkills", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTeacherXTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTeacherXTeacherSkillResponseModel>> TeacherXTeacherSkillUpdateAsync(int id, ApiTeacherXTeacherSkillRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TeacherXTeacherSkills/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTeacherXTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TeacherXTeacherSkillDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TeacherXTeacherSkills/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTeacherXTeacherSkillResponseModel> TeacherXTeacherSkillGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherXTeacherSkills/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTeacherXTeacherSkillResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeacherXTeacherSkillResponseModel>> TeacherXTeacherSkillAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherXTeacherSkills?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeacherXTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTeacherXTeacherSkillResponseModel>> TeacherXTeacherSkillBulkInsertAsync(List<ApiTeacherXTeacherSkillRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherXTeacherSkills/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTeacherXTeacherSkillResponseModel>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>08267e1e2a489f3d5656f396190bead0</Hash>
</Codenesium>*/