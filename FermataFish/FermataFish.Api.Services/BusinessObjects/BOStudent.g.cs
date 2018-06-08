using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public partial class BOStudent: AbstractBusinessObject
        {
                public BOStudent() : base()
                {
                }

                public void SetProperties(int id,
                                          DateTime birthday,
                                          string email,
                                          bool emailRemindersEnabled,
                                          int familyId,
                                          string firstName,
                                          bool isAdult,
                                          string lastName,
                                          string phone,
                                          bool smsRemindersEnabled,
                                          int studioId)
                {
                        this.Birthday = birthday;
                        this.Email = email;
                        this.EmailRemindersEnabled = emailRemindersEnabled;
                        this.FamilyId = familyId;
                        this.FirstName = firstName;
                        this.Id = id;
                        this.IsAdult = isAdult;
                        this.LastName = lastName;
                        this.Phone = phone;
                        this.SmsRemindersEnabled = smsRemindersEnabled;
                        this.StudioId = studioId;
                }

                public DateTime Birthday { get; private set; }

                public string Email { get; private set; }

                public bool EmailRemindersEnabled { get; private set; }

                public int FamilyId { get; private set; }

                public string FirstName { get; private set; }

                public int Id { get; private set; }

                public bool IsAdult { get; private set; }

                public string LastName { get; private set; }

                public string Phone { get; private set; }

                public bool SmsRemindersEnabled { get; private set; }

                public int StudioId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>41b868b7cd487bb697bf9cb6ebab417d</Hash>
</Codenesium>*/