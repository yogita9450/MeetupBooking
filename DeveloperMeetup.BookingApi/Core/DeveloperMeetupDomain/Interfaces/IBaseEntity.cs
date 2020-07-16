﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DeveloperMeetupDomain.Interface
{
    public interface IBaseEntity
    {
        object Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
    }

    public interface IBaseEntity<T> : IBaseEntity
    {
        new T Id { get; set; }
    }
}

