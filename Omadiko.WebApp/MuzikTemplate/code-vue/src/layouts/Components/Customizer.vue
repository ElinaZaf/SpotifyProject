<template>
  <div>
    <RightSideBar toggleClass="setting-toggle">
      <i class="fa fa-spinner fa-spin font-size-24" slot="icon" />
      <iq-card class="shadow-none">
        <template v-slot:body>
          <b-row>
            <b-col cols="12" class="justify-content-between">
              <h4 class="text-left mb-2 sub-color">Muzik Awesome Color</h4>
              <p class="sub-text">This color combo available inside whole template. You can change on your wish, Even you can create your own with limitless possibilities! </p>
              <div class="text-center">
                <div
                  v-for="(item,index) in colors"
                  :key="index"
                  class="d-inline-flex justify-content-between "
                >
                  <div
                    id="color-box"
                    :style="`background: ${item.primary};position: relative;width: 50px;height: 40px;float: left;border-radius: 5px; cursor: pointer;margin: 0 10px 10px 0;`"
                    @click="changeColor(item)"
                    class="p-3 mx-1"
                    :class="item.primary == setColor ? 'iq-colormark' : '' "
                  ></div>
                </div>
              </div>
               <a target="_blank" class="btn btn-primary d-block mt-3 text-white" href="https://themeforest.net/item/muzik-music-streaming-admin-template/27967164">Purchase Now</a>
            </b-col>
          </b-row>
        </template>
      </iq-card>
    </RightSideBar>
  </div>
</template>
<script>
// import darkLoader from '../../assets/images/darkMode/dark-logo.gif'
import loader from '../../assets/images/loader.gif'
import RightSideBar from '../../components/core/rightsidebar/RightSideBar'
import { mapActions, mapGetters } from 'vuex'
export default {
  name: 'Customizer',
  components: {
    RightSideBar
  },
  computed: {
    ...mapGetters({
      darkMode: 'Setting/darkModeState',
      colors: 'Setting/colorState'
    })
  },
  mounted () {
    this.updateRadio()
  },
  data () {
    return {
      setColor: '#ff4545',
      animated: { enter: 'fadeInUp', exit: 'fadeOutDown' },
      animateClass: [
        { value: { enter: 'fadeInUp', exit: 'fadeOutDown' }, text: 'Fade' },
        {
          value: { enter: 'slideInLeft', exit: 'slideOutRight' },
          text: 'Slide'
        },
        {
          value: { enter: 'rotateInDownLeft', exit: 'rotateOutDownLeft' },
          text: 'Roll'
        }
      ],
      logo: loader,
      rtl: false,
      dark: false,
      mini: false,
      notShowMiniSidebar: ['dashboard.home-1'],
      notShowSidebarSetting: [
        'dashboard.home-1'
      ]
    }
  },
  methods: {
    themeMode (mode) {
      this.dark = mode
      this.modeChange({ rtl: this.rtl, dark: mode })
      if (mode) {
        // this.logo = darkLoader
      } else {
        this.logo = loader
      }
      this.$emit('onLogo', this.logo)
    },
    changeColor (code) {
      this.setColor = code.primary
      document.documentElement.style.setProperty('--iq-primary', code.primary)
      // var element = document.getElementById('color-box')
      // element.classList.add('iq-colormark')
      document.documentElement.style.setProperty(
        '--iq-primary-light',
        code.primaryLight
      )
      if (this.darkMode) {
        document.documentElement.style.setProperty(
          '--iq-bg-dark-color',
          code.bodyBgDark
        )
      } else {
        document.documentElement.style.setProperty(
          '--iq-bg-light-color',
          code.bodyBgLight
        )
      }
    },
    reset () {
      this.changeColor({
        primary: '#ff4545',
        primaryLight: '#b47af3',
        bodyBgLight: '#efeefd',
        bodyBgDark: '#1d203f'
      })
      this.animated = { enter: 'fadeInUp', exit: 'fadeOutDown' }
      this.themeMode(false)
      this.rtlChange(false)
    },
    rtlChange (mode) {
      this.rtl = mode
      this.modeChange({ rtl: mode, dark: this.darkMode })
      if (this.darkMode) {
        // this.logo = darkLoader
      } else {
        this.logo = loader
      }
    },
    updateRadio () {
      this.mini = this.$store.getters['Setting/miniSidebarState']
    },
    async miniSidebar () {
      this.$emit('toggle')
      await this.$nextTick()
      this.updateRadio()
    },
    async animateChange () {
      await this.$nextTick()
      this.$emit('animationChange', this.animated)
    },
    ...mapActions({
      modeChange: 'Setting/layoutModeAction'
    })
  }
}
</script>
