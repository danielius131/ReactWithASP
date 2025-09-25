using System.ComponentModel.DataAnnotations;


namespace ReactyWithAsp.Server.Models.Entities;


    public abstract class Entity<T>
    {
        [Key] public T Id { get; protected set; }
    }
