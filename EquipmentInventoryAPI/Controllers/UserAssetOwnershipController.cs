using AutoMapper;
using EquipmentInventoryAPI.DataAccess.Models;
using EquipmentInventoryAPI.DataAccess.Repositories;
using EquipmentInventoryAPI.Library.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentInventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAssetOwnershipController : ControllerBase
    {
        private readonly IUserAssetsOwnershipRepository _userOwnershipRepository;
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public UserAssetOwnershipController(IUserAssetsOwnershipRepository userOwnershipRepository,
                                            IUserRepository userRepository,
                                            IMapper mapper)
        {
            _mapper = mapper;
            _userOwnershipRepository = userOwnershipRepository;
            _userRepository = userRepository;
        }

        // GET: api/UserAssetOwnership
        [HttpGet]
        public async Task<ActionResult<ICollection<ShowUserAssetsOwnershipDto>>> GetUsersAssets()
        {
            var userAssets = _userOwnershipRepository.GetUserAssetsOwnership().ToList();
            var userAssetsDto = new List<ShowUserAssetsOwnershipDto>();

            for (int i = 0; i < userAssets.Count; i++)
            {
                var userAssetDto = new ShowUserAssetsOwnershipDto();

                userAssetDto.Assets = _mapper.Map<ICollection<ShowUserAssetDto>>(userAssets[i].Assets);
                userAssetDto.User = _mapper.Map<ShowUserDto>(_userRepository.GetUserById(userAssets[i].UserId));

                userAssetsDto.Add(userAssetDto);
            }

            return Ok(userAssetsDto);
        }

        // GET: api/UserAssetOwnership/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShowUserAssetsOwnershipDto>> GetUserAssetsOwnershipByUserId(string id)
        {
            var userAssetsOwnership = _userOwnershipRepository.GetUserAssetOwnershipByUserId(Guid.Parse(id));

            if (userAssetsOwnership == null)
                return NotFound();

            var userAssetsOwnershipDto = new ShowUserAssetsOwnershipDto();
            userAssetsOwnershipDto.User = _mapper.Map<ShowUserDto>(_userRepository.GetUserById(userAssetsOwnership.UserId));
            userAssetsOwnershipDto.Assets = _mapper.Map<ICollection<ShowUserAssetDto>>(userAssetsOwnership.Assets);

            return Ok(userAssetsOwnershipDto);
        }

        // GET: api/UserAssetOwnership/OwnedOver/5
        [HttpGet("OwnedOver/{months}")]
        public async Task<ActionResult<ICollection<ShowUserAssetsOwnershipDto>>> GetUserAssetsOwnedOverPeriodOfTime(int months)
        {
            var userAssetsOwnership = _userOwnershipRepository.GetUserAssetOwnershipOwnedOver(months);
            var userAssetsOwnershipDto = new List<ShowUserAssetsOwnershipDto>();

            foreach (var usersAssets in userAssetsOwnership)
            {
                var userAssets = new ShowUserAssetsOwnershipDto();

                userAssets.User = _mapper.Map<ShowUserDto>(_userRepository.GetUserById(usersAssets.UserId));
                userAssets.Assets = _mapper.Map<ICollection<ShowUserAssetDto>>(usersAssets.Assets);

                userAssetsOwnershipDto.Add(userAssets);
            }

            return Ok(userAssetsOwnershipDto);
        }

        // POST: api/UserAssetOwnership/Aquire
        [HttpPost("Aquire")]
        public async Task<ActionResult<ShowAssetDto>> AquireUserAssetOwnership(AddUserAssetOwnershipDto addUserAsset)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userAsset = _mapper.Map<UserAsset>(addUserAsset.Asset);
            userAsset.Id = Guid.NewGuid();

            userAsset.AquireDate = DateTimeOffset.UtcNow;
            userAsset.DisposalDate = null;

            var userOwnershipInfo = _userOwnershipRepository.GetUserAssetOwnershipByUserId(addUserAsset.UserId);

            if (userOwnershipInfo == null)
            {
                userOwnershipInfo = new UserAssetsOwnership();
                userOwnershipInfo.UserId = addUserAsset.UserId;
            }

            userOwnershipInfo.Assets.Add(userAsset);
            _userOwnershipRepository.AddUserAssetOwnership(userOwnershipInfo);

            var userAssetsOwnershipDto = new ShowUserAssetsOwnershipDto();
            userAssetsOwnershipDto.User = _mapper.Map<ShowUserDto>(_userRepository.GetUserById(userOwnershipInfo.UserId));
            userAssetsOwnershipDto.Assets = _mapper.Map<ICollection<ShowUserAssetDto>>(userOwnershipInfo.Assets);

            return CreatedAtAction("GetUserAssetsOwnershipByUserId", new { id = addUserAsset.UserId }, userAssetsOwnershipDto);
        }

        // PUT: api/UserAssetOwnership/Dispose
        [HttpPut("Dispose")]
        public async Task<ActionResult<ShowAssetDto>> DisposeUserAssetOwnership(string id, DisposeUserAssetOwnershipDto disposeUserAsset)
        {
            if (Guid.Parse(id) != disposeUserAsset.UserId || !ModelState.IsValid)
                return BadRequest(ModelState);

            var userAssetsOwnership = _userOwnershipRepository.GetUserAssetOwnershipByUserId(disposeUserAsset.UserId);

            if (userAssetsOwnership == null)
            {
                return NotFound();
            }
            else
            {
                userAssetsOwnership.Assets.Where(x => x.Id == disposeUserAsset.UserAssetId).FirstOrDefault().DisposalDate = DateTimeOffset.UtcNow;

                _userOwnershipRepository.UpdateUserAssetOwnership(userAssetsOwnership);
            }

            return NoContent();
        }

        // PUT: api/UserAssetOwnership/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAssetOwnership(string id, UpdateUserAssetsOwnershipDto userAssetsOwnership)
        {
            if (Guid.Parse(id) != userAssetsOwnership.UserId || !ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userOwnershipRepository.CheckIfUserAssetOwnershipExist(userAssetsOwnership.UserId))
            {
                return NotFound();
            }
            else
            {
                var updatedAssetOwnership = new UserAssetsOwnership()
                {
                    UserId = userAssetsOwnership.UserId
                };
                updatedAssetOwnership.Assets = _mapper.Map<ICollection<UserAsset>>(userAssetsOwnership.Assets);

                _userOwnershipRepository.UpdateUserAssetOwnership(updatedAssetOwnership);
            }

            return NoContent();
        }

        // DELETE: api/UserAssetOwnership/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAssetOwnership(string id)
        {
            var userAssetOwnership = _userOwnershipRepository.GetUserAssetOwnershipByUserId(Guid.Parse(id));

            if (userAssetOwnership == null)
                return NotFound();

            _userOwnershipRepository.RemoveUserAssetOwnership(userAssetOwnership);

            return NoContent();
        }
    }
}
