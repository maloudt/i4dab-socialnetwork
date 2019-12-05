using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Views
{
    class Views
    {
        public void ViewUserFeed()
        {
            // feed(logged_in_user_id) -> show the users feed - including
            // the latest xx posts the uses has access rights
        }

        public void ViewUserWall()
        {
            // wall(user_id, guest_id) -> show the wall, including at least the
            // latest xx posts from the user, which the guest_id user has access rights to
        }

    }
}
