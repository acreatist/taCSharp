using MusicCollection.Data;
using MusicCollection.Model;
using MusicCollection.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicCollection.WebAPI.Controllers
{
    public class ArtistsController : ApiController
    {
        private readonly IRepository<Artist> entityRepo;

        public ArtistsController()
        {
            this.entityRepo = new DbArtistsRepository(new MusicContext());
        }

        public ArtistsController (IRepository<Artist> repo)
        {
            this.entityRepo = repo;
        }

        // GET
        public IEnumerable<ArtistModel> GetAll()
        {
            var artists = this.entityRepo.All();

            var artistsToReturn =
                from a in artists
                select new ArtistModel()
                {
                    ArtistId = a.ArtistId,
                    Name = a.Name,
                    BirthDate = a.BirthDate,
                    Country = a.Country
                };

            return artistsToReturn.ToList();

        }

        // GET(id)
        public ArtistModelFull GetSingle(int id)
        {
            var artist = this.entityRepo.Get(id);

            var artistToReturn = new ArtistModelFull()
            {
                ArtistId = artist.ArtistId,
                Name = artist.Name,
                BirthDate = artist.BirthDate,
                Country = artist.Country,
                Songs = (
                    from s in artist.Songs
                    select new SongModel()
                    {
                        SongId = s.SongId,
                        Gender = s.Gender,
                        Title = s.Title,
                        Year = s.Year
                    }
                )
            };

            return artistToReturn;
        }

        // POST
        // url/api/Artists/?albumId=<album id>
        public HttpResponseMessage PostArtist(int albumId, [FromBody]Artist item)
        {
            if (item == null)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Message");

                return errResponse;
            }

            var addedArtist = this.entityRepo.Add(item, albumId);

            var response = Request.CreateResponse(HttpStatusCode.Created);

            return response;
        }
        // PUT
        public HttpResponseMessage PutArtist(int id, [FromBody]Artist item)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != item.ArtistId || item.ArtistId == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Must provide the AlbumId");
            }

            var updatedArtist = this.entityRepo.Update(id, item);

            var response = Request.CreateResponse(HttpStatusCode.Accepted, updatedArtist);

            return response;
        }

        // DELETE
        public HttpResponseMessage DeleteArtist(int id)
        {
            var artistToDelete = this.entityRepo.Get(id);
            this.entityRepo.Delete(artistToDelete);

            var response = Request.CreateResponse(HttpStatusCode.Accepted);

            return response;
        }
    }
}
