using System;

namespace Application.Repository.Model
{
    public class Group
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string Name { get; set; }
    }
}