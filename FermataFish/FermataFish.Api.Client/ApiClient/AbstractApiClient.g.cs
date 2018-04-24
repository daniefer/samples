using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
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

		public AbstractApiClient(string apiUri, string apiVersion)
		{
			if (string.IsNullOrWhiteSpace(apiUri))
			{
				throw new ArgumentException("apiUrl is not set");
			}
			if (apiUri[apiUri.Length - 1] != '/')
			{
				throw new ArgumentException("The apiUrl must end in a / for httpClient to work correctly");
			}
			if (string.IsNullOrWhiteSpace(apiVersion))
			{
				throw new ArgumentException("apiVersion is not set");
			}

			this.ApiUrl = apiUri;
			this.ApiVersion = apiVersion;
			this.client = new HttpClient();

			this.client.BaseAddress = new Uri(apiUri);

			this.client.DefaultRequestHeaders.Accept.Clear();
			this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			this.client.DefaultRequestHeaders.Add("api-version", this.ApiVersion);
		}

		public virtual async Task<POCOAdmin> AdminCreateAsync(AdminModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Admins", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAdmin>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAdmin> AdminUpdateAsync(int id, AdminModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Admins/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAdmin>(httpResponse.Content.ContentToString());
		}

		public virtual async Task AdminDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Admins/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOAdmin>> AdminSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Admins?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAdmin>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOAdmin> AdminGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Admins/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOAdmin>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOAdmin>> AdminGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Admins?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOAdmin>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> AdminBulkInsertAsync(List<AdminModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Admins/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOFamily> FamilyCreateAsync(FamilyModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Families", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOFamily>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOFamily> FamilyUpdateAsync(int id, FamilyModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Families/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOFamily>(httpResponse.Content.ContentToString());
		}

		public virtual async Task FamilyDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Families/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOFamily>> FamilySearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Families?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOFamily>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOFamily> FamilyGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Families/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOFamily>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOFamily>> FamilyGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Families?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOFamily>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> FamilyBulkInsertAsync(List<FamilyModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Families/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLesson> LessonCreateAsync(LessonModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Lessons", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLesson>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLesson> LessonUpdateAsync(int id, LessonModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Lessons/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLesson>(httpResponse.Content.ContentToString());
		}

		public virtual async Task LessonDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Lessons/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOLesson>> LessonSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lessons?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLesson>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLesson> LessonGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lessons/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLesson>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLesson>> LessonGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Lessons?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLesson>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> LessonBulkInsertAsync(List<LessonModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Lessons/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLessonStatus> LessonStatusCreateAsync(LessonStatusModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonStatus", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLessonStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLessonStatus> LessonStatusUpdateAsync(int id, LessonStatusModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LessonStatus/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLessonStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task LessonStatusDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LessonStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOLessonStatus>> LessonStatusSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonStatus?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLessonStatus>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLessonStatus> LessonStatusGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonStatus/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLessonStatus>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLessonStatus>> LessonStatusGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonStatus?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLessonStatus>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> LessonStatusBulkInsertAsync(List<LessonStatusModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonStatus/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLessonXStudent> LessonXStudentCreateAsync(LessonXStudentModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonXStudents", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLessonXStudent>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLessonXStudent> LessonXStudentUpdateAsync(int id, LessonXStudentModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LessonXStudents/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLessonXStudent>(httpResponse.Content.ContentToString());
		}

		public virtual async Task LessonXStudentDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LessonXStudents/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOLessonXStudent>> LessonXStudentSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonXStudents?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLessonXStudent>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLessonXStudent> LessonXStudentGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonXStudents/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLessonXStudent>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLessonXStudent>> LessonXStudentGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonXStudents?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLessonXStudent>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> LessonXStudentBulkInsertAsync(List<LessonXStudentModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonXStudents/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLessonXTeacher> LessonXTeacherCreateAsync(LessonXTeacherModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonXTeachers", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLessonXTeacher>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLessonXTeacher> LessonXTeacherUpdateAsync(int id, LessonXTeacherModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LessonXTeachers/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLessonXTeacher>(httpResponse.Content.ContentToString());
		}

		public virtual async Task LessonXTeacherDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LessonXTeachers/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOLessonXTeacher>> LessonXTeacherSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonXTeachers?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLessonXTeacher>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOLessonXTeacher> LessonXTeacherGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonXTeachers/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOLessonXTeacher>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOLessonXTeacher>> LessonXTeacherGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LessonXTeachers?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOLessonXTeacher>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> LessonXTeacherBulkInsertAsync(List<LessonXTeacherModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LessonXTeachers/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCORate> RateCreateAsync(RateModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Rates", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCORate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCORate> RateUpdateAsync(int id, RateModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Rates/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCORate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task RateDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Rates/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCORate>> RateSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Rates?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCORate>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCORate> RateGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Rates/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCORate>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCORate>> RateGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Rates?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCORate>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> RateBulkInsertAsync(List<RateModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Rates/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpace> SpaceCreateAsync(SpaceModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Spaces", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpace>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpace> SpaceUpdateAsync(int id, SpaceModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Spaces/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpace>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SpaceDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Spaces/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOSpace>> SpaceSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Spaces?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpace>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpace> SpaceGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Spaces/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpace>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSpace>> SpaceGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Spaces?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpace>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> SpaceBulkInsertAsync(List<SpaceModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Spaces/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpaceFeature> SpaceFeatureCreateAsync(SpaceFeatureModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceFeatures", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpaceFeature>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpaceFeature> SpaceFeatureUpdateAsync(int id, SpaceFeatureModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SpaceFeatures/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpaceFeature>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SpaceFeatureDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SpaceFeatures/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOSpaceFeature>> SpaceFeatureSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceFeatures?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpaceFeature>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpaceFeature> SpaceFeatureGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceFeatures/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpaceFeature>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSpaceFeature>> SpaceFeatureGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceFeatures?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpaceFeature>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> SpaceFeatureBulkInsertAsync(List<SpaceFeatureModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceFeatures/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpaceXSpaceFeature> SpaceXSpaceFeatureCreateAsync(SpaceXSpaceFeatureModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceXSpaceFeatures", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpaceXSpaceFeature>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpaceXSpaceFeature> SpaceXSpaceFeatureUpdateAsync(int id, SpaceXSpaceFeatureModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/SpaceXSpaceFeatures/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpaceXSpaceFeature>(httpResponse.Content.ContentToString());
		}

		public virtual async Task SpaceXSpaceFeatureDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/SpaceXSpaceFeatures/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOSpaceXSpaceFeature>> SpaceXSpaceFeatureSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceXSpaceFeatures?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpaceXSpaceFeature>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOSpaceXSpaceFeature> SpaceXSpaceFeatureGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceXSpaceFeatures/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOSpaceXSpaceFeature>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOSpaceXSpaceFeature>> SpaceXSpaceFeatureGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/SpaceXSpaceFeatures?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOSpaceXSpaceFeature>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> SpaceXSpaceFeatureBulkInsertAsync(List<SpaceXSpaceFeatureModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/SpaceXSpaceFeatures/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOState> StateCreateAsync(StateModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/States", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOState>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOState> StateUpdateAsync(int id, StateModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/States/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOState>(httpResponse.Content.ContentToString());
		}

		public virtual async Task StateDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/States/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOState>> StateSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/States?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOState>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOState> StateGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/States/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOState>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOState>> StateGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/States?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOState>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> StateBulkInsertAsync(List<StateModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/States/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStudent> StudentCreateAsync(StudentModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Students", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStudent>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStudent> StudentUpdateAsync(int id, StudentModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Students/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStudent>(httpResponse.Content.ContentToString());
		}

		public virtual async Task StudentDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Students/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOStudent>> StudentSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Students?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStudent>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStudent> StudentGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Students/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStudent>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOStudent>> StudentGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Students?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStudent>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> StudentBulkInsertAsync(List<StudentModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Students/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStudentXFamily> StudentXFamilyCreateAsync(StudentXFamilyModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/StudentXFamilies", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStudentXFamily>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStudentXFamily> StudentXFamilyUpdateAsync(int id, StudentXFamilyModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/StudentXFamilies/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStudentXFamily>(httpResponse.Content.ContentToString());
		}

		public virtual async Task StudentXFamilyDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/StudentXFamilies/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOStudentXFamily>> StudentXFamilySearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StudentXFamilies?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStudentXFamily>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStudentXFamily> StudentXFamilyGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StudentXFamilies/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStudentXFamily>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOStudentXFamily>> StudentXFamilyGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/StudentXFamilies?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStudentXFamily>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> StudentXFamilyBulkInsertAsync(List<StudentXFamilyModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/StudentXFamilies/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStudio> StudioCreateAsync(StudioModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Studios", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStudio>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStudio> StudioUpdateAsync(int id, StudioModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Studios/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStudio>(httpResponse.Content.ContentToString());
		}

		public virtual async Task StudioDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Studios/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOStudio>> StudioSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStudio>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOStudio> StudioGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOStudio>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOStudio>> StudioGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Studios?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOStudio>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> StudioBulkInsertAsync(List<StudioModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Studios/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTeacher> TeacherCreateAsync(TeacherModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teachers", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeacher>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTeacher> TeacherUpdateAsync(int id, TeacherModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Teachers/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeacher>(httpResponse.Content.ContentToString());
		}

		public virtual async Task TeacherDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Teachers/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOTeacher>> TeacherSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teachers?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTeacher>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTeacher> TeacherGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teachers/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeacher>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTeacher>> TeacherGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Teachers?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTeacher>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> TeacherBulkInsertAsync(List<TeacherModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Teachers/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTeacherSkill> TeacherSkillCreateAsync(TeacherSkillModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherSkills", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeacherSkill>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTeacherSkill> TeacherSkillUpdateAsync(int id, TeacherSkillModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TeacherSkills/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeacherSkill>(httpResponse.Content.ContentToString());
		}

		public virtual async Task TeacherSkillDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TeacherSkills/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOTeacherSkill>> TeacherSkillSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherSkills?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTeacherSkill>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTeacherSkill> TeacherSkillGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherSkills/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeacherSkill>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTeacherSkill>> TeacherSkillGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherSkills?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTeacherSkill>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> TeacherSkillBulkInsertAsync(List<TeacherSkillModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherSkills/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTeacherXTeacherSkill> TeacherXTeacherSkillCreateAsync(TeacherXTeacherSkillModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherXTeacherSkills", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeacherXTeacherSkill>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTeacherXTeacherSkill> TeacherXTeacherSkillUpdateAsync(int id, TeacherXTeacherSkillModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/TeacherXTeacherSkills/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeacherXTeacherSkill>(httpResponse.Content.ContentToString());
		}

		public virtual async Task TeacherXTeacherSkillDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/TeacherXTeacherSkills/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOTeacherXTeacherSkill>> TeacherXTeacherSkillSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherXTeacherSkills?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTeacherXTeacherSkill>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOTeacherXTeacherSkill> TeacherXTeacherSkillGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherXTeacherSkills/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOTeacherXTeacherSkill>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOTeacherXTeacherSkill>> TeacherXTeacherSkillGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/TeacherXTeacherSkills?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOTeacherXTeacherSkill>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> TeacherXTeacherSkillBulkInsertAsync(List<TeacherXTeacherSkillModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/TeacherXTeacherSkills/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>4e84802830de27634d4ff7c76f0ede8f</Hash>
</Codenesium>*/