﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Core.Entities
{
    public class AdvertisementForSales : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(User))]
        public Guid? userId { get; set; }
        public GameAccount gameAccount  { get; set; }

        [ForeignKey(nameof(gameAccount))]
        public Guid? gameAccountId { get; set; }
        public AdvertisementStatus? advertisementStatus { get; set; }

        [ForeignKey(nameof(advertisementStatus))]
        public Guid? advertisementStatusId { get; set; }
        public bool IsActive { get; set; }
    }
}
