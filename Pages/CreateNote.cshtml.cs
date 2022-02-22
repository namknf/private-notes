﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateNotes.Pages
{
    public class CreateNoteModel : PageModel
    {
        private readonly ILogger<CreateNoteModel> _logger;

        public CreateNoteModel(ILogger<CreateNoteModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}