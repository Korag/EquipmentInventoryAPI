using EquipmentInventoryAPI.DataAccess.Models;
using EquipmentInventoryAPI.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquipmentInventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly ILogger<DeviceController> _logger;
        private readonly IDeviceRepository _deviceRepository;

        public DeviceController(ILogger<DeviceController> logger, IDeviceRepository deviceRepository)
        {
            _logger = logger;
            _deviceRepository = deviceRepository;
        }

        // GET: api/Device
        [HttpGet]
        public async Task<ActionResult<ICollection<IDevice>>> GetDevices()
        {
            var devices = _deviceRepository.GetDevices();
            return Ok(devices);
        }

        // GET: api/Device/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IDevice>> GetDevice(int id)
        {
            var device = _deviceRepository.GetDeviceById(id);

            if (device == null)
                return NotFound();

            return Ok(device);
        }

        // POST: api/Device
        [HttpPost]
        public async Task<ActionResult<IDevice>> PostDevice(IDevice device)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_deviceRepository.CheckIfDeviceExist(device.Id))
            {
                return Conflict();
            }
            else
            {
                _deviceRepository.AddDevice(device);
            }

            return CreatedAtAction("GetDevice", new { id = device.Id }, device);
        }

        // PUT: api/Device
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevice(int id, IDevice device)
        {
            if (id != device.Id || !ModelState.IsValid)
                return BadRequest(ModelState);


            if (!_deviceRepository.CheckIfDeviceExist(device.Id))
            {
                return NotFound();
            }
            else
            {
                _deviceRepository.UpdateDevice(device);
            }

            return NoContent();
        }

        // DELETE: api/Device/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var device = _deviceRepository.GetDeviceById(id);

            if (device == null)
                return NotFound();

            _deviceRepository.RemoveDevice(device);
            return NoContent();
        }
    }
}
