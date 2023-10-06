using Dictionary.Domain.Data.Entity;
using Dictionary.Web.Handlers.Contracts;
using Dictionary.Web.Infrastructure.Extensions;
using Dictionary.Web.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.Web.Controllers
{
    [Route("api/words")]
    [Authorize]
    public class WordController : ControllerBase
    {
        private readonly IWordHandler _wordHandler;
        public WordController(IWordHandler wordHandler) 
        {
            _wordHandler = wordHandler;
        }

        [HttpGet("get-words")]
        public ActionResult<IEnumerable<Word>> GetWords()
        {
           
            return Ok(_wordHandler.Get());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Word> GetWord(int id)
        {
            
            return Ok(_wordHandler.Get(id)); 
        }

        [HttpPost("add-word")]
        public ActionResult AddWord([FromBody] AddWordRequest request)
        {
            _wordHandler.Add(User.GetId(), request);
            return Ok();
        }

        [HttpPatch("update-word")]
        public ActionResult UpdateWord(UpdateWordRequest request)
        {
            _wordHandler.Update(User.GetId(), request);
            return Ok();
        }

        [HttpDelete("{id:int}/delete-word")]
        public ActionResult DeleteWord(int id)
        {
            _wordHandler.Delete(id);
            return Ok();
        }

        [HttpDelete("delete-words")]
        public ActionResult DeleteWords([FromBody] IEnumerable<int> ids)
        {
            _wordHandler.Delete(ids);
            return Ok();
        }
    }
}
