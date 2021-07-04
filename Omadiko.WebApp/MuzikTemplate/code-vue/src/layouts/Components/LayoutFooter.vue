<template>
  <div>
    <MiniFooter>
      <!-- <audio ref="audio" :src=track.path ></audio> -->
      <div class="player row">
        <div class="details col-6 col-sm-4 col-md-4 col-lg-4">
          <div class="now-playing"></div>
          <div class="track-art"></div>
          <div>
            <div class="track-name">{{ track.name }}</div>
            <div class="track-artist">{{ track.artist }}</div>
          </div>
        </div>
        <div class="slider_container slider_music col-sm-5 col-md-4 col-lg-4">
          <div class="current-time">{{ currentTime }}</div>
          <input type="range" min="1" max="100" value="0" class="seek_slider" v-model="trackSlider" @change="seekTo" >
          <div class="total-duration">{{ totalDuration }}</div>
        </div>
        <div class="buttons col-6 col-sm-3 col-md-2 col-lg-2">
          <div class="prev-track"  @click="prevTrack"><i class="fa fa-step-backward fa-2x"></i></div>
          <div class="playpause-track"  @click="playPauseTrack"><i :class="`fa fa-${playButtonClass}-circle fa-3x`"></i></div>
          <div class="next-track"  @click="nextTrack"><i class="fa fa-step-forward fa-2x"></i></div>
        </div>
        <div class="slider_container sound col-sm-6 col-md-2  col-lg-2">
          <i class="fa fa-volume-down"></i>
          <input type="range" min="1" max="100" value="100" v-model="trackVolume" class="volume_slider" @change="setVolume">
          <i class="fa fa-volume-up"></i>
        </div>
      </div>
    </MiniFooter>
  </div>
</template>
<script>
import MiniFooter from '../../components/core/footer/MiniFooter'
import { APPNAME } from '../../config/pluginInit'
import { player } from '../../mixins/player-mixin'
import { musics } from '../../StaticData/json/musics'
export default {
  name: 'LayoutFooter',
  mixins: [player],
  components: {
    MiniFooter
  },
  mounted () {
    this.track = musics[0]
    this.loadTrack()
  },
  data () {
    return {
      appName: APPNAME
    }
  },
  methods: {
    beforePrevTrackLoad () {
      this.track = musics[0]
    },
    beforeNextTrackLoad () {
      this.track = musics[1]
    }
  }
}
</script>
