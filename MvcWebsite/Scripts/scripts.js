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
            var $clickedRow = $(this);
            // if ingredient was added to shoplist delete it:
            if ($(this).hasClass("selectedIngredient")) {
                var ingredientName = $(this).children('.ingredientNameTd').get(0).textContent;
                var $tr = $(this);

                $.ajax({
                    url: 'https://cookbookapp.azurewebsites.net/api/Shoplist/' + usrId + '/' + ingredientName,
                    type: 'DELETE',
                    success: function () {
                        $clickedRow.toggleClass("selectedIngredient");
                    }
                });

                return;
            }
            // else add it to list
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
                    $clickedRow.toggleClass("selectedIngredient");
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

    $('#sendNewItem').submit(function (event) {
        event.preventDefault();

        var $form = $(this), url = $form.attr("action");
        var $successful = $("#successfulSubmit");

        if (validate()) {
            var posting = $.post(url, {
                IngredientName: $("#IngredientName").val(),
                Amount: $("#Amount").val(),
                Unit: $("#Unit").val()
            });

            posting.done(function (data) {
                alert("Shoping list item was added. Refresh page to show it on list");
            });
        }
    });
})

function validate() {
    var name = document.getElementById("IngredientName").value;
    var amount = document.getElementById("Amount").value;
    var unit = document.getElementById("Unit").value;

    if (name.length < 2 || name.length >= 60) {
        document.getElementById("ingrNameValidation").innerText = "Product name length must be greater than 1 and lower than 60";
        return false;
    }
    else if (isNaN(+amount)) {
        document.getElementById("amountValidation").innerText = "Amount must be a number";
        return false;
    }
    else if (unit.length >= 10) {
        document.getElementById("unitValidation").innerText = "Unit length must be greater than lower than 10";
        return false;
    }
    else if (! /^[a-zA-Z0-9]+$/.test(name) || ! /^[a-zA-Z0-9]+$/.test(unit) || ! /^[a-zA-Z0-9]+$/.test(amount)) {
        document.getElementById("additionalValidationInfo").innerText = "Field contains characters which are not allowed.";
    }
    else {
        return true;
    }
}