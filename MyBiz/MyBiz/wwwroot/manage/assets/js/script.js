$(document).ready(function () {
    $(".sweet-delete").click(function (e) {
        e.preventDefault(e);

        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                let url = $(this).attr("href");
                fetch(url).
                    then(response => {
                        if (response.ok) {
                            window.location.reload();
                        }
                        else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Oops...',
                                text: 'Please, choose the right teammember!',
                                footer: '<a href="">There is no such teammember.</a>'
                            })
                        }
                    })

                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )
            }
        })
    })
})

$(document).ready(function () {
    $(".navbar-nav .nav-link").click(function () {
        $(this).addClass("active").siblings.removeClass("active");
    })
})