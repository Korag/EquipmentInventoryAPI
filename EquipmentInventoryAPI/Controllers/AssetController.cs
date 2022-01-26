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
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IUserAssetsOwnershipRepository _userOwnershipRepository;

        private readonly IMapper _mapper;

        public AssetController(IAssetRepository assetRepository, 
                               IUserAssetsOwnershipRepository userOwnershipRepository, 
                               IMapper mapper)
        {
            _assetRepository = assetRepository;
            _userOwnershipRepository = userOwnershipRepository;
            _mapper = mapper;
        }

        // GET: api/Asset
        [HttpGet]
        public async Task<ActionResult<ICollection<ShowAssetDto>>> GetAssets()
        {
            var assets = _assetRepository.GetAssets().ToList();
            var assetsDto = _mapper.Map<List<ShowAssetDto>>(assets);

            return Ok(assetsDto);
        }

        // GET: api/Asset/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShowAssetDto>> GetAsset(string id)
        {
            var asset = _assetRepository.GetAssetById(Guid.Parse(id));

            if (asset == null)
                return NotFound();

            var assetDto = _mapper.Map<ShowAssetDto>(asset);

            return Ok(assetDto);
        }

        // GET: api/Asset/User/5
        [HttpGet("User/{id}")]
        public async Task<ActionResult<ICollection<ShowAssetDto>>> GetAssetsByOwnerId(string id)
        {
            var userAssets = _assetRepository.GetAssetByUserId(Guid.Parse(id)).ToList();

            if (userAssets.Count() == 0)
                return NotFound();

            var assetsDto = _mapper.Map<ICollection<ShowAssetDto>>(userAssets).ToList();

            return Ok(assetsDto);
        }

        // POST: api/Asset
        [HttpPost]
        public async Task<ActionResult<ShowAssetDto>> PostAsset(AddAssetDto asset)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newAsset = _mapper.Map<Asset>(asset);
            newAsset.Id = Guid.NewGuid();

            _assetRepository.AddAsset(newAsset);

            foreach (var owner in newAsset.Owners)
            {
                var userAssetOwnership = _mapper.Map<UserAssetOwnership>(newAsset);
                userAssetOwnership.AquireDate = DateTime.Now;
                userAssetOwnership.DisposalDate = DateTime.MinValue;

                var userOwnershipInfo = _userOwnershipRepository.GetUserAssetOwnershipById(owner);

                if (userOwnershipInfo == null)
                {
                    userOwnershipInfo = new UserAssets();

                    userOwnershipInfo.Id = Guid.NewGuid();
                    userOwnershipInfo.OwnerId = owner;
                }

                userOwnershipInfo.Assets.Add(userAssetOwnership);
                _userOwnershipRepository.AddUserAssetOwnership(userOwnershipInfo);
            }

            var assetDto = _mapper.Map<ShowAssetDto>(newAsset);

            return CreatedAtAction("GetAsset", new { id = assetDto.Id }, assetDto);
        }

        // PUT: api/Asset
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsset(string id, UpdateAssetDto asset)
        {
            if (Guid.Parse(id) != asset.Id || !ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_assetRepository.CheckIfAssetExist(asset.Id))
            {
                return NotFound();
            }
            else
            {
                var updatedAsset = _mapper.Map<Asset>(asset);
                _assetRepository.UpdateAsset(updatedAsset);
            }

            return NoContent();
        }

        // DELETE: api/Asset/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsset(string id)
        {
            var asset = _assetRepository.GetAssetById(Guid.Parse(id));

            if (asset == null)
                return NotFound();

            _assetRepository.RemoveAsset(asset);

            foreach (var owner in asset.Owners)
            {
                //var userOwnerShipInfo = _userOwnershipRepository.GetUserAssetOwnershipById(owner);

                //if (userOwnerShipInfo != null)
                //{
                //    if (userOwnerShipInfo.Assets.Select(x => x.Id).Contains(Guid.Parse(id)))
                //    {
                //        _userOwnershipRepository.
                //    }
                //}

                //TODO:
                //Remove Ownership
                //UserController
                //UserRepo
                //GetUserDevicesOwnershipHistory
                //GetDevicesWhichLastsLongerThan3YearsInOwnership
                //Add missing tests

                //Add Angular simple GUI
            }

            return NoContent();
        }
    }
}
