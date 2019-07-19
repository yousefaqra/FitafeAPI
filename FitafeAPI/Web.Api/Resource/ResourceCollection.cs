﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitafeAPI.Web.Api.Resource
{
    public class ResourceCollection<TResource>
    {
        /// <summary>
        /// Retrieves an empty list
        /// </summary>
        public ResourceCollection()
        {
            Items = Enumerable.Empty<TResource>();
        }

        /// <summary>
        /// Retrieves the list.
        /// </summary>
        /// <param name="items">Items to be returned</param>
        public ResourceCollection(IEnumerable<TResource> items)
        {
            Items = items;
        }

        /// <summary>
        /// Retrieves the list and counts the items
        /// </summary>
        /// <param name="items">Items to be returned</param>
        /// <param name="totalResults">Number of items in list</param>
        public ResourceCollection(
            IEnumerable<TResource> items,
            long totalResults)
        {
            Items = items;
            TotalResults = totalResults;
        }

        /// <summary>
        /// Retrieves the list, counts the items and the elapsed time
        /// </summary>
        /// <param name="items">Items to be returned</param>
        /// <param name="totalResults">Number of items in list</param>
        /// <param name="elapsedMilliseconds">Elapsed time in milliseconds</param>
        /// <param name="aggregateGroup">Resource Group (Total, Url, Name</param>
        public ResourceCollection(
            IEnumerable<TResource> items,
            long totalResults,
            long elapsedMilliseconds)
        {
            Items = items;
            TotalResults = totalResults;
            ElapsedMilliseconds = elapsedMilliseconds;
        }

        /// <summary>
        /// Elapsed time of the query.
        /// </summary>
        public long ElapsedMilliseconds { get; set; }

        /// <summary>
        /// Collection of items.
        /// </summary>
        public IEnumerable<TResource> Items { get; set; }

        /// <summary>
        /// Total items count.
        /// </summary>
        /// <remarks>Useful for paging.</remarks>
        public long TotalResults { get; set; }

    }
}
