﻿using System;
using AutoMapper;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.WebApi.Mappings
{
	public class ImageMapping : Profile
	{
		public new string ProfileName
		{
			get { return "ImageMapping"; }
		}

		[Obsolete("Use the constructor instead. Will be removed in 6.0")]
		protected override void Configure()
		{
			this.CreateMap<ImageModel, ImageViewModel>()
				.ForMember(url => url.ImageUrl, x => x.MapFrom(src => src.ImageUrl));
		}
	}
}