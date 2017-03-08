$(document).ready(function () {

    // animations
    $(".recipeIngredientRow").hover(
        function () {
            $(this).toggleClass("hoveredTd")
        },
        function () {
            $(this).toggleClass("hoveredTd")
        });
    $(".shopListItemRow").hover(
        function () {
            $(this).toggleClass("hoveredTd")
        },
        function () {
            $(this).toggleClass("hoveredTd")
        });

    // webservice calls
    $(".recipeIngredientRow").click(
        function () {
            var ingredientName = $(this).children('.ingredientNameTd').get(0).textContent;
            var ingredientAmount = $(this).children('.ingredientAmountTd').get(0).textContent;
            var ingredientUnit = $(this).children('.ingredientUnitTd').get(0).textContent;

            var shopListItem = {
                "IngredientName": ingredientName,
                "Amount": ingredientAmount,
                "Unit": ingredientUnit
            };

            $.ajax({
                url: 'https://cookbookapp.azurewebsites.net/api/Shoplist/' + usrId + '/Add',
                type: 'POST',
                data: shopListItem,
                dataType: "application/json",
                success: function () {
                    alert('OK');
                }
            })
        });

    $(".shopListItemRow").click(
        function () {
            var ingredientName = $(this).children('.ingredientNameTd').get(0).textContent;
            var $tr = $(this); 

            $.ajax({
                url: 'https://cookbookapp.azurewebsites.net/api/Shoplist/' + usrId + '/' + ingredientName, 
                type: 'DELETE',
                success: function () {
                    $tr.remove();
                }  
            })
        });
})
