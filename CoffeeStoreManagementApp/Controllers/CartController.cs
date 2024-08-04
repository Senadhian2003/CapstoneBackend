using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Models.DTO;
using CoffeeStoreManagementApp.Services;
using CoffeeStoreManagementApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeStoreManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartServices _cartServices;
        private readonly ILogger<CartController> _logger;

        public CartController(ICartServices cartServices, ILogger<CartController> logger)
        {
            _cartServices = cartServices;
            _logger = logger;
        }

        [Authorize(Roles = "User")]
        [HttpPost("AddCoffeeToCart")]
        [ProducesResponseType(typeof(CartItem), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> AddCoffeeToCart(AddItemToCartDTO addItemToCartDTO)
        {
            try
            {
                var userstring = User.Claims?.FirstOrDefault(x => x.Type == "Id")?.Value;
                var userId = Convert.ToInt32(userstring);
                var result = await _cartServices.AddItemToCart(userId, addItemToCartDTO);
                return Ok(result);
            }
            catch (ElementNotFoundException uue)
            {
                _logger.LogError(uue, "Element not found while adding coffee to cart");
                return NotFound(new ErrorModel(404, uue.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding coffee to cart");
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorModel(500, ex.Message));
            }
        }

        [Authorize(Roles = "User")]
        [HttpPut("UpdateCartItemQuantity")]
        [ProducesResponseType(typeof(CartItem), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> UpdateCartItemQuantityToCart(UpdateCartItemDTO updateCartItemDTO)
        {
            try
            {
                var result = await _cartServices.UpdateCartItemQuantity(updateCartItemDTO);
                return Ok(result);
            }
            catch (ElementNotFoundException enf)
            {
                _logger.LogError(enf, "Element not found while updating cart item quantity");
                return NotFound(new ErrorModel(404, enf.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating cart item quantity");
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorModel(500, ex.Message));
            }
        }

        [Authorize(Roles = "User")]
        [HttpGet("GetCartItems")]
        [ProducesResponseType(typeof(List<CartItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> GetAllCartItems()
        {
            try
            {
                var userstring = User.Claims?.FirstOrDefault(x => x.Type == "Id")?.Value;
                var userId = Convert.ToInt32(userstring);
                var result = await _cartServices.GetCartItems(userId);
                return Ok(result);
            }
            catch (EmptyListException ele)
            {
                _logger.LogError(ele, "No items found in cart");
                return NotFound(new ErrorModel(404, ele.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving cart items");
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorModel(500, ex.Message));
            }
        }

        [Authorize(Roles = "User")]
        [HttpDelete("DeleteCartItem")]
        [ProducesResponseType(typeof(CartItem), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> DeleteCartItem(int cartItemId)
        {
            try
            {
                var result = await _cartServices.DeleteCartItem(cartItemId);
                return Ok(result);
            }
            catch (ElementNotFoundException enfe)
            {
                _logger.LogError(enfe, "Element not found while deleting cart item");
                return NotFound(new ErrorModel(404, enfe.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting cart item");
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorModel(500, ex.Message));
            }
        }

        [Authorize(Roles = "User")]
        [HttpPost("CheckoutCart")]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> CheckoutCart()
        {
            try
            {
                var userstring = User.Claims?.FirstOrDefault(x => x.Type == "Id")?.Value;
                var userId = Convert.ToInt32(userstring);
                var result = await _cartServices.CheckoutCart(userId);
                return Ok(result);
            }
            catch (EmptyListException ele)
            {
                _logger.LogError(ele, "No items found in cart for checkout");
                return Unauthorized(new ErrorModel(404, ele.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while checking out cart");
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorModel(500, ex.Message));
            }
        }
    }
}
