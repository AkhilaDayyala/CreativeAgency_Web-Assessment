
$(document).ready(function () {
    function filterAndSortPosts() {
        const category = $("#categoryFilter").val();
        const sort = $("#sortDate").val();
        const posts = $(".blog-post").toArray();

        const filtered = posts.filter(p => {
            return category === "all" || $(p).data("category") === category;
        });

        filtered.sort((a, b) => {
            const dateA = new Date($(a).data("date"));
            const dateB = new Date($(b).data("date"));
            return sort === "asc" ? dateA - dateB : dateB - dateA;
        });

        $("#blogList").empty().append(filtered);
    }

    $("#categoryFilter, #sortDate").on("change", filterAndSortPosts);
});
