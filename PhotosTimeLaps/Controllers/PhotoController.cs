using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using PhotosTimeLaps.Photo;

namespace PhotosTimeLaps.Controllers
{
    [RoutePrefix("api/photo")]
    public class PhotoController : ApiController
    {
        private readonly IPhotoManager _photoManager;

        public PhotoController()
            : this(new LocalPhotoManager(System.Web.Hosting.HostingEnvironment.MapPath("~/Album")))
        {            
        }

        public PhotoController(IPhotoManager photoManager)
        {
            _photoManager = photoManager;
        }

        // GET: api/Photo
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var results = await _photoManager.Get();
                return Ok(new {photos = results});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.StackTrace);
            }
        }

        // POST: api/Photo
        public async Task<IHttpActionResult> Post()
        {
            // Check if the request contains multipart/form-data.
            if(!Request.Content.IsMimeMultipartContent("form-data"))
            {
                return BadRequest("Unsupported media type");
            }

            try
            {
                var photos = await _photoManager.Add(Request);
                return Ok(new { Message = "Photos uploaded ok", Photos = photos });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.StackTrace);
            }
            
        }

        // DELETE: api/Photo/5
        [HttpDelete]
        [Route("{fileName}")]
        public async Task<IHttpActionResult> Delete(string fileName)
        {         
            if (!_photoManager.FileExists(fileName))
            {
                return NotFound();
            }

           var result = await _photoManager.Delete(fileName);

           if (result.Successful)
           {
               return Ok(new { message = result.Message});
           } else
           {
               return BadRequest(result.Message);
           }
        }
    }
}
