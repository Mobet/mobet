﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mobet.Domain;

namespace Mobet.Domain.Entities
{

    /// <summary>
    /// Defines interface for base IAggregateRoot type. All AggregateRoot in the system must implement this interface.
    /// </summary>
    public interface IAggregateRoot : IEntity
    {
        byte[] Version { get; set; }
    }

    /// <summary>
    /// Defines interface for base IAggregateRoot type. All AggregateRoot in the system must implement this interface.
    /// </summary>
    /// <typeparam name="TPrimaryKey">Type of the primary key of the entity</typeparam>
    public interface IAggregateRoot<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        byte[] Version { get; set; }
    }
}
