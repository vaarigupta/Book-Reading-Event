﻿using AutoMapper;
using Nagarro.BookReading.Application.Interfaces;
using Nagarro.BookReading.Application.Models;
using Nagarro.BookReading.Web.Interfaces;
using Nagarro.BookReading.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.BookReading.Web.Services
{
    public class CommentPageService : ICommentPageService
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentPageService(ICommentService commentService, IMapper mapper)
        {
            this._commentService = commentService;
            this._mapper = mapper;
        }

        public async Task<int> PostComment(CommentViewModel commentViewModel)
        {
            var mapped = _mapper.Map<CommentModel>(commentViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");
            return await _commentService.PostComment(mapped);
        }

        public async Task<IList<CommentViewModel>> GetComments()
        {
            var list = await _commentService.GetComments();
            var mapped = _mapper.Map<IList<CommentViewModel>>(list);
            return mapped;
        }

        public async Task<CommentViewModel> ViewComment(int commentId)
        {
            var _comment = await _commentService.ViewComment(commentId);
            var mapped = _mapper.Map<CommentViewModel>(_comment);
            return mapped;
        }

        public int EditComment(CommentViewModel commentViewModel)
        {
            var mapped = _mapper.Map<CommentModel>(commentViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            return _commentService.EditComment(mapped);
        }
    }
}
