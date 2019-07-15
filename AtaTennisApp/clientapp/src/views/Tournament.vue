<template>
    <d-container>
        <d-row>
            <d-col>
                <d-card>
                    <!--<img src="http://localhost/wwwclientapp/src/assets/images/300x200.gif">-->
                    <d-card-img src="http://images.sportspromedia.com/images/made/images/uploads/news/tennis_grass_court_generic_630_354_80_s_c1.jpg"></d-card-img>
                </d-card>
            </d-col>
            <d-col>
                <d-card-header>{{tournament.Name}}</d-card-header>
                <d-card-body>
                    <p>blaaa</p>
                    <p>asf</p>
                </d-card-body>
                <d-card-footer>Card footer</d-card-footer>
            </d-col>
        </d-row>
        <d-row>
        </d-row>
    </d-container>
</template>

<script>
    //import { Player } from '../../Api/TournamentController'

    export default {
        name: 'Tournament',
        data: function () {
            return {
                tournament: { Name: "" }
            }
        },
        mounted: function () {
            //var tournament = new Tournament()
            //natiahnut data z bekendu ...
            var tournament = {
                Name: "Wimbledon"};
            this.tournament = tournament;
        },
    }
</script>