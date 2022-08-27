using AspNetCoreGraphQLClient.Models;
using AspNetCoreGraphQLClient.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Collections.Generic;

namespace AspNetCoreGraphQLClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPlayerService _playerService;

        public IEnumerable<Player>? Players { get; set; }

        public IndexModel(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Players = await _playerService.GetAllPlayersAsync();
            return Page();
        }
    }
}