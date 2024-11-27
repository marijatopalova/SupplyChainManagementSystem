﻿namespace SCMS.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
    }
}
