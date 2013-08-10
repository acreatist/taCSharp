using MusicCollection.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MusicCollection.Model;
using System.Data.Entity;
using MusicCollection.Data;

namespace MusicCollection.WebAPI.Controllers
{
    public class AlbumsController : ApiController
    {
        private IRepository<Album> entityRepo;

        public AlbumsController()
        {
            this.entityRepo = new DbAlbumsRepository(new MusicContext());
        }

        public AlbumsController (IRepository<Album> repo)
        {
            this.entityRepo = repo;
        }

        // GET
        public IEnumerable<AlbumModel> GetAll()
        {
            var allAlbums = this.entityRepo.All();

            var returnAlbums =
                from a in allAlbums
                select new AlbumModel()
                {
                    AlbumId = a.AlbumId,
                    Title = a.Title,
                    Producer = a.Producer,
                    Year = a.Year
                };

            return returnAlbums.ToList();
        }

        // GET/id
        public AlbumModelFull GetSingle(int id)
        {
            var album = this.entityRepo.Get(id);

            var albumToReturn = new AlbumModelFull()
            {
                AlbumId = album.AlbumId,
                Title = album.Title,
                Producer = album.Producer,
                Year = album.Year,
                Artists = (
                    from art in album.Artists
                    select new ArtistModel()
                    {
                        ArtistId = art.ArtistId,
                        Name = art.Name,
                        Country = art.Country,
                        BirthDate = art.BirthDate
                    }
                ).ToList()
            };

            return albumToReturn;
        }

        // POST
        public HttpResponseMessage PostAlbum(Album item)
        {
            if (item == null)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Message");

                return errResponse;
            }

            var addedAlbum = this.entityRepo.Add(item);

            var response = Request.CreateResponse(HttpStatusCode.Created, addedAlbum);

            return response;
        }

        // PUT
        public HttpResponseMessage PutAlbum(int id, [FromBody]Album item)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != item.AlbumId || item.AlbumId == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Must provide the AlbumId");
            }

            var updatedAlbum = this.entityRepo.Update(id, item);

            var response = Request.CreateResponse(HttpStatusCode.Accepted, updatedAlbum);

            return response;
        }


        // DELETE
        public HttpResponseMessage DeleteAlbum(int id)
        {
            var albumToDelete = this.entityRepo.Get(id);
            this.entityRepo.Delete(albumToDelete);

            var response = Request.CreateResponse(HttpStatusCode.Accepted); // comes from the ApiController

            return response;
        }

    }
}
