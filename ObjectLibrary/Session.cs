﻿using System;
using System.Runtime.Serialization;
namespace ObjectLibrary
{
    [DataContract]
    public sealed class Session : BaseObject
    {
        [DataMember(Order = 100)]
        public long FkUser { get; set; }
        [DataMember(Order = 101)]
        public DateTime CreateDate { get; set; }

        public Session()
        {
        }

        public Session(long id, string name, long fkUser, DateTime createDate) : base(id, name)
        {
            FkUser = fkUser;
            CreateDate = createDate;
        }

        //public class SessionMap : ClassMap<Session>
        //{
        //    public SessionMap()
        //    {
        //        Id(x => x.ID).Column("ID").GeneratedBy.Identity();
        //        Map(x => x.Name);
        //        Map(x => x.FkUser);
        //        Map(x => x.CreateDate);
        //    }
        //}
    }
}
