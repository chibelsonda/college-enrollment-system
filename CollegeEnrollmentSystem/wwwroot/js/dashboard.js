$(function () {

    /* Breakpoint used for mobile behavior */
    const breakpoint = 992;

    /* Tracks if the user manually toggled the sidebar */
    let userToggled = false;

    /* Check if current screen is considered mobile */
    function isMobile() {
        return $(window).width() <= breakpoint;
    }

    /* 
       Automatically show/hide sidebar based on screen size
       - Only applies if the user has NOT manually toggled
    */
    function applyResponsiveSidebar() {
        if (!userToggled) {
            if (isMobile()) {
                $('#sidebar').addClass('collapsed');
                $('.content').addClass('full');
            } else {
                $('#sidebar').removeClass('collapsed');
                $('.content').removeClass('full');
            }
        }
    }

    /* Apply sidebar state on first load */
    applyResponsiveSidebar();

    /* Re-evaluate sidebar when window is resized */
    $(window).on('resize', applyResponsiveSidebar);

    /* 
       Hamburger button
       - Toggles sidebar manually
       - User intent takes priority over resize logic
    */
    $('#toggleSidebar').on('click', function (e) {
        e.stopPropagation();
        userToggled = true;

        $('#sidebar').toggleClass('collapsed');
        $('.content').toggleClass('full');
    });

    /* 
       Click outside sidebar (content area)
       - Only closes sidebar on mobile
    */
    $('.content').on('click', function () {
        if (isMobile() && !$('#sidebar').hasClass('collapsed')) {
            userToggled = true;

            $('#sidebar').addClass('collapsed');
            $('.content').addClass('full');
        }
    });

    /* 
       Initialize all sidebar dropdowns manually
       - Avoids Bootstrap auto-toggle issues
    */
    const sidebarCollapses = {};

    $('.sidebar-collapse').each(function () {
        sidebarCollapses[this.id] = new bootstrap.Collapse(this, {
            toggle: false
        });
    });

    /* 
       Sidebar dropdown toggle
       - Accordion behavior (only one open at a time)
       - Rotates arrow icon
    */
    $('.sidebar-toggle').on('click', function (e) {
        e.stopPropagation();

        const targetId = $(this).data('target').replace('#', '');

        /* Update arrow state */
        $('.sidebar-toggle').not(this).removeClass('active');
        $(this).toggleClass('active');

        /* Close other dropdowns */
        Object.keys(sidebarCollapses).forEach(id => {
            if (id !== targetId) {
                sidebarCollapses[id].hide();
            }
        });

        /* Toggle selected dropdown */
        sidebarCollapses[targetId].toggle();
    });

    /* 
       Marks sidebar as ready
       - Prevents initial flash on mobile
    */
    $('body').addClass('sidebar-ready');

});
