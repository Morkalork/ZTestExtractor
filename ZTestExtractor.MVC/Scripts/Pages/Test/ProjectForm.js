(function ()
{
    function loadTests()
    {
        var projectId = $("#project").val();
        if (projectId === "-1")
        {
            return;
        }

        var projectVersionId = $("#projectVersion").val();
        if (projectVersion === "-1")
        {
            return;
        }

        var data = {
            projectId: projectId,
            projectVersionId: projectVersionId
        };

        $.ajax({
            url: "/Project/Tests",
            type: "POST",
            data: data
        })
        .done(function (result)
        {
            $("#projectContent")
                .html(result)
                .slideDown();
        });
    }

    function loadProjectVersionContent(projectVersionId)
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
            url: "/Project/Versions",
            type: "POST",
            data: data
        })
        .done(function (result)
        {
            $("#projectContent")
                .html(result)
                .slideDown();
        });
    }

    function bind()
    {
        $("#project")
            .on("change", loadProjectVersionContent);
    }

    function init()
    {
        bind();
    }

    init();
})();