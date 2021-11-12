﻿using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Bases
{

    /// <summary>
    /// 创建，删除
    /// </summary>
    [Index(nameof(CreateTime)), Index(nameof(DeleteTime))]
    public class CD
    {

        /// <summary>
        /// 主键标识ID
        /// </summary>
        public long Id { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }



        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }



        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }




        /// <summary>
        /// 行版本标记
        /// </summary>
        /// <remarks>通用的RowVersion</remarks>
        [ConcurrencyCheck]
        public long? RowVersion { get; set; }




        ///// <summary>
        ///// 行版本标记
        ///// </summary>
        ///// <remarks>PostgreSql的RowVersion</remarks>

        //public uint xmin { get; set; }



        ///// <summary>
        ///// 行版本标记
        ///// </summary>
        ///// <remarks>SqlServer的RowVersion</remarks>
        //[Timestamp]
        //public byte[] RowVersion { get; set; }

    }
}
