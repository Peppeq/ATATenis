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

<script lang="ts">
    import Vue from 'vue';
    import Component from 'vue-class-component';
    import TournamentClient, { Tournament } from '../Api/TournamentController'
import { BaseComponentClass } from '../common/BaseComponentClass';
import { NotificationUtils } from '../common/notification';

    @Component
    export default class TournamentClass extends BaseComponentClass {
        tournament?: Tournament = new Tournament();
        async mounted() {
            var _this = this;
            console.log('tour was mounted');
            var tournamentClient = new TournamentClient();
            //natiahnut data z bekendu ...
            await tournamentClient.get({ Id: 1 }).then((tournament: Tournament) => {
                _this.tournament = tournament;
            }).catch((reason: Error) => {
                NotificationUtils.ShowErrorMessage('hahaaaaaaaaaaaa');
            });
            //var tournament = {
            //    Name: "Wimbledon"};
        }
    }
</script>