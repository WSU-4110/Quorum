using QuorumDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace QuorumDB
{
    public class ForumData : IForumData
    {
        private readonly IDbAccess _db;

        public ForumData(IDbAccess db)
        {
            _db = db;
        }

        public Task<List<Forum>> GetAllForums()
        {
            string sql = "select * from dbo.Forums";
            return _db.LoadData<Forum, dynamic>(sql, new { });
        }

        public Task<List<Forum>> GetForumsByParentId(int Id)
        {
            string sql = $"select * from dbo.Forums where ForumID = '{Id}'";
            return _db.LoadData<Forum, dynamic>(sql, new { });
        }

        public Task<List<Forum>> GetForumById(int id)
        {
            string sql = $"select * from dbo.Forums where Id = @Id";
            return _db.LoadData<Forum, dynamic>(sql, new { Id = id});
        }

        //HARD CODED
        public Task<List<Forum>> GetSearchQuorum(string input)
        {
            string sql = "DECLARE @Keyword AS VARCHAR(100) SET @Keyword = '" + input + "' select* from dbo.Forums where dbo.Forums.Title = @Keyword OR dbo.Forums.Description = @Keyword";
            return _db.LoadData<Forum, dynamic>(sql, new { });
        }

        //HARD CODED
        public Task<List<Forum>> GetSearchSection(string input)
        {
            string sql = "select * from dbo.Forums where ForumID = 3 AND dbo.Forums.Title = '" + input + "';";
            return _db.LoadData<Forum, dynamic>(sql, new { });
        }

        public Task<List<Forum>> GetForumByURL(string input)
        {
            string sql = "select * from dbo.Forums where dbo.Forums.Url = '" + input + "';";
            return _db.LoadData<Forum, dynamic>(sql, new { });
        }

        public Task<List<string>> GetForumURL(int Id)
        {
            string sql = $"select Url from dbo.Forums where dbo.Forums.Id = '{Id}'";
            return _db.LoadData<string, dynamic>(sql, new { });
        }

        public Task< List<int> > GetCurrentForumID(string input)
        {
            string sql = $"select Id from dbo.Forums where dbo.Forums.Url = '{input}'";
            return _db.LoadData<int, dynamic>(sql, new { });
        }

        //HARD CODED
        /*public Task<List<AspNetUser>> GetSearchPost()
        {
            string input = "Arts"; // Set this to an input
            string sql = "select * from dbo.Forums where ForumID = 3 AND dbo.Forums.Title = '" + input + "';";
            return _db.LoadData<AspNetUser, dynamic>(sql, new { });
        }*/
    }

    public class GetAllForumsCommand : ICommand {
        ForumData forumdata;

        public void Execute()
        {
            forumdata.GetAllForums();
        }
    }

    public class GetForumsByParentIdCommand : ICommand {
        ForumData forumdata;
        int id;

        public GetForumsByParentIdCommand(ForumData forumdata, int id) {
            this.forumdata = forumdata;
            this.id = id;
        }

        public void Execute()
        {
            forumdata.GetForumsByParentId(id);
        }
    }

    public class GetForumByIdCommand : ICommand {
        ForumData forumdata;
        int id;

        public GetForumByIdCommand(ForumData forumdata, int id)
        {
            this.forumdata = forumdata;
            this.id = id;
        }

        public void Execute()
        {
            forumdata.GetForumById(id);
        }
    }

    public class GetSearchQuorumCommand : ICommand {
        ForumData forumdata;
        string stringInp;

        public GetSearchQuorumCommand(ForumData forumdata, string stringInp)
        {
            this.forumdata = forumdata;
            this.stringInp = stringInp;
        }

        public void Execute()
        {
            forumdata.GetSearchQuorum(stringInp);
        }
    }

    public class GetSearchSectionCommand : ICommand {
        ForumData forumdata;
        string stringInp;

        public GetSearchSectionCommand(ForumData forumdata, string stringInp)
        {
            this.forumdata = forumdata;
            this.stringInp = stringInp;
        }

        public void Execute()
        {
            forumdata.GetSearchSection(stringInp);
        }
    }

    public class GetForumByURLCommand : ICommand {
        ForumData forumdata;
        string stringInp;

        public GetForumByURLCommand(ForumData forumdata, string stringInp)
        {
            this.forumdata = forumdata;
            this.stringInp = stringInp;
        }

        public void Execute()
        {
            forumdata.GetForumByURL(stringInp);
        }
    }

    public class GetForumURLCommand : ICommand {
        ForumData forumdata;
        int id;

        public GetForumURLCommand(ForumData forumdata, int id)
        {
            this.forumdata = forumdata;
            this.id = id;
        }

        public void Execute()
        {
            forumdata.GetForumURL(id);
        }
    }

    public class GetCurrentForumIDCommand : ICommand {
        ForumData forumdata;
        string stringInp;

        public GetCurrentForumIDCommand(ForumData forumdata, string stringInp)
        {
            this.forumdata = forumdata;
            this.stringInp = stringInp;
        }

        public void Execute()
        {
            forumdata.GetCurrentForumID(stringInp);
        }
    }
}
