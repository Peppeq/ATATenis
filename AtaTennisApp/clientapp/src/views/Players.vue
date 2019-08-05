<template>
    <div>
        <h1>List of Players</h1>
        <div v-for="(player,index) in players" v-bind:key="player.id">
            <div><label>{{index}}.</label>{{player.Name}}</div>
        </div>
    </div>
</template>

<script lang="ts">
    import PlayerClient, { Player } from '../Api/PlayerController'
    import { Component, Vue } from 'vue-property-decorator';

    @Component
    export default class PlayersView extends Vue {
        players: Player[] = [];
        async mounted() {
            var client = new PlayerClient();
            console.log(client);
            await client.getWithoutParams()
                .then(result => { console.log(result); this.players = result.Players })
                .catch((reason) => { alert("something went wrong with player " + reason); });
        }
    }
</script>