(function ()
{
    function saveConfiguration(model)
    {
        var data = {
            model: model
        };

        $.ajax({
            url: "/Home/Configure",
            type: "POST",
            data: data
        })
        .done(function (result)
        {
            //TODO: Improve UI :)
            var output = "Result:\n--------\n" + result.Messages.join("\n");
            alert(output);
        });
    }

    function bind()
    {
        $("#save_database_settings")
            .click(function ()
            {
                //Get the model
                var model = {
                    ServerName: $("#server_name").val(),
                    DatabaseName: $("#database_name").val(),
                    Username: $("#username").val(),
                    Password: $("#password").val(),
                    DatabaseSystem: $("#database_system").val()
                };

                saveConfiguration(model);
            });
    }

    function init()
    {
        bind();
    }

    init();
})();