(function ()
{
    function loadProjectContent(projectId)
    {
        var projectId = $("#project").val();
        if (projectId === "-1")
        {
            return;
        }

        var data = {
            projectId: projectId
        };

        $.ajax({
            url: "/Test/Show",
            type: "POST",
            data: data
        })
        .done(function (result)
        {
            console.log(result);
            $("#projectContent")
                .html(result)
                .slideDown();
        });
    }

    function bind()
    {
        $("#project")
            .on("change", loadProjectContent);
    }

    function init()
    {
        bind();
    }

    init();
})();