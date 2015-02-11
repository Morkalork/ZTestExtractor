(function ()
{
    function saveConfiguration(model)
    {

    }

    function bind()
    {
        $("#save_database_settings")
            .click(function ()
            {
                //Get the model
                var model = null;

                saveConfiguration(model);
            });
    }

    function init()
    {
        bind();
    }

    init();
})();