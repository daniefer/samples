using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiPostsResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int? acceptedAnswerId,
                        int? answerCount,
                        string body,
                        DateTime? closedDate,
                        int? commentCount,
                        DateTime? communityOwnedDate,
                        DateTime creationDate,
                        int? favoriteCount,
                        DateTime lastActivityDate,
                        DateTime? lastEditDate,
                        string lastEditorDisplayName,
                        int? lastEditorUserId,
                        int? ownerUserId,
                        int? parentId,
                        int postTypeId,
                        int score,
                        string tags,
                        string title,
                        int viewCount)
                {
                        this.Id = id;
                        this.AcceptedAnswerId = acceptedAnswerId;
                        this.AnswerCount = answerCount;
                        this.Body = body;
                        this.ClosedDate = closedDate;
                        this.CommentCount = commentCount;
                        this.CommunityOwnedDate = communityOwnedDate;
                        this.CreationDate = creationDate;
                        this.FavoriteCount = favoriteCount;
                        this.LastActivityDate = lastActivityDate;
                        this.LastEditDate = lastEditDate;
                        this.LastEditorDisplayName = lastEditorDisplayName;
                        this.LastEditorUserId = lastEditorUserId;
                        this.OwnerUserId = ownerUserId;
                        this.ParentId = parentId;
                        this.PostTypeId = postTypeId;
                        this.Score = score;
                        this.Tags = tags;
                        this.Title = title;
                        this.ViewCount = viewCount;
                }

                public int? AcceptedAnswerId { get; private set; }

                public int? AnswerCount { get; private set; }

                public string Body { get; private set; }

                public DateTime? ClosedDate { get; private set; }

                public int? CommentCount { get; private set; }

                public DateTime? CommunityOwnedDate { get; private set; }

                public DateTime CreationDate { get; private set; }

                public int? FavoriteCount { get; private set; }

                public int Id { get; private set; }

                public DateTime LastActivityDate { get; private set; }

                public DateTime? LastEditDate { get; private set; }

                public string LastEditorDisplayName { get; private set; }

                public int? LastEditorUserId { get; private set; }

                public int? OwnerUserId { get; private set; }

                public int? ParentId { get; private set; }

                public int PostTypeId { get; private set; }

                public int Score { get; private set; }

                public string Tags { get; private set; }

                public string Title { get; private set; }

                public int ViewCount { get; private set; }
        }
}

/*<Codenesium>
    <Hash>739e6faffb19d7c602889b2e0291e82d</Hash>
</Codenesium>*/