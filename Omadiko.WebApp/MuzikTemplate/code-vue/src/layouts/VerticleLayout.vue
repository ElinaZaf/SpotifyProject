<template>
  <div>
    <Loader />
    <Customizer @onLogo="changeLogo" @toggle="sidebarMini" @animationChange="routerAnimationChange" />
      <!-- Sidebar  -->
      <SmallSidebar v-if="$route.name === 'dashboard.home-5'" :logo="SmallSidebarLogo" @toggle="sidebarMini" />
      <Sidebar :items="verticalMenu" :logo="logo" :onlyLogo="onlyLogo" :onlyLogoText="onlyLogoText" @toggle="sidebarMini" :toggleButton="toggleSideIcon" :sidebarGroupTitle="sidebarGroupTitle" />
      <!-- TOP Nav Bar -->
      <DefaultNavBar title="Dashboard" :homeURL="{ name: 'dashboard.home-1' }" :sidebarGroupTitle="sidebarGroupTitle" @toggle="sidebarMini" :logo="logo">
        <template slot="responsiveRight">
          <ul class="navbar-nav ml-auto navbar-list">
            <li class="nav-item nav-icon">
              <div class="iq-search-bar">
                  <form action="#" class="searchbox">
                    <input type="text" class="text search-input" @click="openSearch" v-model="globalSearch" placeholder="Search Here..">
                    <a class="search-link" href="#"><i class="ri-search-line text-black"></i></a>
                    <a class="search-audio" href="#"><i class="las la-microphone text-black"></i></a>
                    <!-- <GlobalSearch :search="globalSearch" @closeSearch="removeClass "/> -->
                  </form>
              </div>
            </li>
            <li class="nav-item nav-icon search-content">
              <a href="#" class="search-toggle iq-waves-effect text-gray rounded"><span class="ripple rippleEffect"></span>
                <i class="ri-search-line text-black"></i>
              </a>
              <form action="#" class="search-box p-0">
                <input type="text" class="text search-input" @click="openSearch" v-model="globalSearch" placeholder="Search Here..">
                <a class="search-link" href="#"><i class="ri-search-line text-black"></i></a>
                <a class="search-audio" href="#"><i class="las la-microphone text-black"></i></a>
              </form>
            </li>
            <li class="nav-item nav-icon">
              <a href="#" class="search-toggle iq-waves-effect text-black rounded">
                <i class="las la-cog"></i>
                <span class=" dots"></span>
              </a>
            </li>
            <li class="nav-item nav-icon">
              <a href="#" class="search-toggle iq-waves-effect text-black rounded">
                <i class="lar la-envelope"></i>
                <span class="massage-icon dots badge badge-primary">5</span>
              </a>
              <div class="iq-sub-dropdown">
                <div class="iq-card shadow-none m-0">
                  <div class="iq-card-body p-0 ">
                    <div class="bg-primary p-3">
                      <h5 class="mb-0 text-white">{{ $t('nav.allMessages') }}<small class="badge badge-light float-right pt-1">4</small></h5>
                    </div>
                    <a href="#" class="iq-sub-card" v-for="(item, index) in message" :key="index">
                      <div class="media align-items-center">
                        <div class="">
                          <img class="avatar-40 rounded img-fluid" :src="item.image" alt="img">
                        </div>
                        <div class="media-body ml-3">
                          <h6 class="mb-0 ">{{ item.name }}</h6>
                          <small class="float-left font-size-12">{{ item.date }}</small>
                        </div>
                      </div>
                    </a>
                  </div>
                </div>
              </div>
            </li>
            <li class="nav-item nav-icon">
              <a href="#" class="search-toggle iq-waves-effect text-black rounded">
                <i class="ri-notification-line block"></i>
                <span class="notice-icon dots badge badge-primary">+</span>
              </a>
              <div class="iq-sub-dropdown">
                <div class="iq-card shadow-none m-0">
                  <div class="iq-card-body p-0 ">
                    <div class="bg-primary p-3">
                      <h5 class="mb-0 text-white">{{ $t('nav.allNotifications') }}<small class="badge  badge-light float-right pt-1">5</small></h5>
                    </div>
                    <a href="#" class="iq-sub-card" v-for="(item,index) in notification" :key="index">
                      <div class="media align-items-center">
                        <div class="">
                          <img class="avatar-40 rounded" :src="item.image" alt="img">
                        </div>
                        <div class="media-body ml-3">
                          <h6 class="mb-0 ">{{ item.name }}</h6>
                          <small class="float-right">{{ item.date }}</small>
                          <p class="mb-0">{{ item.description }}</p>
                        </div>
                      </div>
                    </a>
                  </div>
                </div>
              </div>
            </li>
            <li class="line-height pt-3">
              <a href="#" class="search-toggle iq-waves-effect d-flex align-items-center">
                <img :src="userProfile" class="img-fluid rounded-circle" alt="user">
              </a>
              <div class="iq-sub-dropdown iq-user-dropdown">
                <div class="iq-card shadow-none m-0">
                  <div class="iq-card-body p-0 ">
                    <div class="bg-primary p-3">
                      <h5 class="mb-0 text-white line-height">Hello Barry Tech</h5>
                      <span class="text-white font-size-12">{{ $t('nav.user.available') }}</span>
                    </div>
                    <router-link to="/user/profile" class="iq-sub-card iq-bg-primary-hover">
                      <div class="media align-items-center">
                        <div class="rounded iq-card-icon iq-bg-primary">
                          <i class="ri-file-user-line"></i>
                        </div>
                        <div class="media-body ml-3">
                          <h6 class="mb-0 ">{{ $t('nav.user.profileTitle') }}</h6>
                          <p class="mb-0 font-size-12">{{ $t('nav.user.profileSub') }}</p>
                        </div>
                      </div>
                    </router-link>
                    <router-link to="/user/profile-edit" class="iq-sub-card iq-bg-primary-hover">
                      <div class="media align-items-center">
                        <div class="rounded iq-card-icon iq-bg-primary">
                          <i class="ri-profile-line"></i>
                        </div>
                        <div class="media-body ml-3">
                          <h6 class="mb-0 ">{{ $t('nav.user.profileEditTitle') }}</h6>
                          <p class="mb-0 font-size-12">{{ $t('nav.user.profileEditSub') }}</p>
                        </div>
                      </div>
                    </router-link>
                    <router-link to="/account-setting" class="iq-sub-card iq-bg-primary-hover">
                      <div class="media align-items-center">
                        <div class="rounded iq-card-icon iq-bg-primary">
                          <i class="ri-account-box-line"></i>
                        </div>
                        <div class="media-body ml-3">
                          <h6 class="mb-0 ">{{ $t('nav.user.accountSettingTitle') }}</h6>
                          <p class="mb-0 font-size-12">{{ $t('nav.user.accountSettingSub') }}</p>
                        </div>
                      </div>
                    </router-link>
                    <router-link to="/privacy-setting" class="iq-sub-card iq-bg-primary-hover">
                      <div class="media align-items-center">
                          <div class="rounded iq-card-icon iq-bg-primary">
                            <i class="ri-lock-line"></i>
                          </div>
                          <div class="media-body ml-3">
                            <h6 class="mb-0">{{ $t('nav.user.privacySettingTitle') }}</h6>
                            <p class="mb-0 font-size-12">{{ $t('nav.user.privacySettingSub') }}</p>
                          </div>
                      </div>
                    </router-link>
                    <div class="d-inline-block w-100 text-center p-3">
                      <a class="bg-primary iq-sign-btn" href="javascript:void(0)" @click="logout" role="button">{{ $t('nav.user.signout') }}<i class="ri-login-box-line ml-2"></i></a>
                    </div>
                  </div>
                </div>
              </div>
            </li>
          </ul>
        </template>
      </DefaultNavBar>
      <!-- TOP Nav Bar END -->
      <div id="content-page" class="content-page">
        <transition name="router-anim" :enter-active-class="`animated ${animated.enter}`" mode="out-in"
                    :leave-active-class="`animated ${animated.exit}`">
          <router-view/>
        </transition>
      </div>
      <!-- <LayoutFixRightSide v-if="$route.name === 'dashboard.home-1' " /> -->
    <LayoutFooter />
  </div>
</template>
<script>
import { core } from '../config/pluginInit'
import { mapActions, mapGetters } from 'vuex'
import Loader from '../components/core/loader/Loader'
import Sidebar from '../components/core/sidebars/Sidebar'
import DefaultNavBar from '../components/core/navbars/DefaultNavBar'
import SideBarItems from '../StaticData/json/SideBar'
import profile from '../assets/images/user/11.png'
import loader from '../assets/images/loader.gif'
import logo from '../assets/images/logo.png'
import darkLoader from '../assets/images/darkMode/dark-loader.gif'
import Customizer from './Components/Customizer'
import SmallSidebar from '../components/core/sidebars/SmallSidebar'
import LayoutFooter from './Components/LayoutFooter'
export default {
  name: 'VerticleLayout',
  components: {
    LayoutFooter,
    Customizer,
    Loader,
    Sidebar,
    DefaultNavBar,
    SmallSidebar
  },
  mounted () {
    this.layoutSetting(this.$route.name)
  },
  computed: {
    ...mapGetters({
      selectedLang: 'Setting/langState',
      langsOptions: 'Setting/langOptionState',
      darkMode: 'Setting/darkModeState',
      colors: 'Setting/colorState'
    }),
    toggleSideIcon () {
      let show = false
      // switch (this.$route.name) {
      //   case 'dashboard.home-1':
      //   case 'dashboard.home-3':
      //   case 'dashboard.home-4':
      //   case 'dashboard.home-5':
      //   case 'dashboard.home-6':
      //     show = false
      //     break
      // }
      return show
    }
  },
  watch: {
    '$route': function (to, from) {
      this.layoutSetting(to.name)
    }
  },
  data () {
    return {
      animated: { enter: 'fadeIn', exit: 'fadeOut' },
      verticalMenu: SideBarItems,
      userProfile: profile,
      onlyLogo: false,
      onlyLogoText: false,
      sidebarGroupTitle: true,
      logo: logo,
      rtl: false,
      SmallSidebarLogo: logo,
      globalSearch: '',
      showSearch: false,
      showMenu: false,
      message: [
        { image: require('../assets/images/user/01.jpg'), name: 'Bni Emma Watson', date: '13 Jun' },
        { image: require('../assets/images/user/02.jpg'), name: 'Lorem Ipsum Watson', date: '20 Apr' },
        { image: require('../assets/images/user/03.jpg'), name: 'Why do we use it?', date: '30 Jun' },
        { image: require('../assets/images/user/04.jpg'), name: 'Variations Passages', date: '12 Sept' },
        { image: require('../assets/images/user/05.jpg'), name: 'Lorem Ipsum generators', date: '5 Dec' }
      ],
      notification: [
        { image: require('../assets/images/user/01.jpg'), name: 'Emma Watson Barry', date: 'Just Now', description: '95 MB' },
        { image: require('../assets/images/user/02.jpg'), name: 'New customer is join', date: '5 days ago', description: 'Cyst Barry' },
        { image: require('../assets/images/user/03.jpg'), name: 'Two customer is left', date: '2 days ago', description: 'Cyst Barry' },
        { image: require('../assets/images/user/04.jpg'), name: 'New Mail from Fenny', date: '3 days ago', description: 'Cyst Barry' }
      ]
    }
  },
  methods: {
    layoutSetting (routeName) {
      this.onlyLogo = true
      this.onlyLogoText = true
      this.sidebarGroupTitle = true
      switch (routeName) {
        case '':
          break
        default:
          if (this.darkMode) {
            this.logo = darkLoader
          } else {
            this.logo = loader
          }
          break
      }
    },
    changeLogo (e) {
      this.logo = e
    },
    sidebarMini () {
      core.triggerSet()
      this.$store.dispatch('Setting/miniSidebarAction')
    },
    logout () {
      localStorage.removeItem('user')
      localStorage.removeItem('access_token')
      this.$router.push({ name: 'auth1.sign-in1' })
    },
    openSearch () {
      this.showSearch = true
      this.showMenu = 'iq-show'
      this.globalSearch = ''
      if (document.getElementById('searchbox-datalink') !== null) {
        document.getElementById('searchbox-datalink').classList.add('show-data')
      }
    },
    closeSearch (event) {
      let classList = event.target.classList
      if (!classList.contains('searchbox') && !classList.contains('search-input')) {
        this.removeClass()
      }
    },
    removeClass () {
      this.showSearch = false
      this.showMenu = ''
      this.globalSearch = ''
      if (document.getElementById('searchbox-datalink') !== null && document.getElementById('searchbox-datalink') !== undefined) {
        document.getElementById('searchbox-datalink').classList.remove('show-data')
      }
    },
    langChange (lang) {
      this.langChangeState(lang)
      this.$i18n.locale = lang.value
      document.getElementsByClassName('iq-show')[0].classList.remove('iq-show')
      if (lang.value === 'ar') {
        this.rtlAdd(lang)
      } else {
        this.rtlRemove(lang)
      }
    },
    routerAnimationChange (e) {
      this.animated = e
    },
    ...mapActions({
      langChangeState: 'Setting/setLangAction',
      rtlAdd: 'Setting/setRtlAction',
      rtlRemove: 'Setting/removeRtlAction'
    })
  }
}
</script>
<style>
  @import url("../assets/css/custom.css");
  @import url("../assets/css/PriceSlider.css");
</style>
