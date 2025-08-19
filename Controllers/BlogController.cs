using Microsoft.AspNetCore.Mvc;
using Web.CreativeAgency.Models;

namespace Web.CreativeAgency.Controllers
{
    public class BlogController : Controller
    {
        private static readonly List<BlogPost> Posts = new()
        {
            new() { Slug="seo-can-transform", Title="How SEO Can Transform Your Business", Category="seo", PublishedOn=new DateTime(2025,6,10), Excerpt="Optimize for traffic and conversions.", Content="Full content here..." },
            new() { Slug="content-is-king-2025", Title="Content is Still King in 2025", Category="content", PublishedOn=new DateTime(2025,5,22), Excerpt="Great content wins.", Content="Full content here..." },
            new() { Slug="social-trends", Title="Top 5 Social Media Trends This Year", Category="social", PublishedOn=new DateTime(2025,6,1), Excerpt="Stay ahead with trends.", Content="Full content here..." },
            new() { Slug="websites-that-convert", Title="Building Modern Websites That Convert", Category="web", PublishedOn=new DateTime(2025,6,15), Excerpt="UX/UI strategies.", Content="Full content here..." }
        };

        [Route("blog")]
        public IActionResult Index() => View(Posts.OrderByDescending(p => p.PublishedOn).ToList());

        [Route("blog/{slug}")]
        public IActionResult Detail(string slug)
        {
            var post = Posts.FirstOrDefault(p => p.Slug == slug);
            if (post == null) return NotFound();
            return View(post);
        }
    }
}
