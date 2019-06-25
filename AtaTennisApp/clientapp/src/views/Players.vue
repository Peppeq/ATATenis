<template>
    <div>
        <h1>List of Players</h1>
        <div v-for="(player,index) in players" v-bind:key="player.id">
            <div><label>{{index}}.</label>{{player.name}}</div>
        </div>  
    </div>
</template>

<script>
    import { Players } from '../../Api/Players.js'

    export default {
        name: 'Players',
        data: function () {
            return {
                players: {}
            }
        },
        mounted: function () {
            var p = new Players()
            p.getData().then(p => this.players = p.players);
        },
    }
</script>