<template>
    <div class="home">
        <banner isHome="true"></banner>
        <div class="site-content animate"> 
            <main class="site-main" :class="{'search':hideSlogan}">
                <section-title v-if="!hideSlogan">Hot Burger Stores</section-title>
                <div style="margin: 30px;">
                    <span>Sort by </span>
                    <button style="margin: 30px;" @click="sortByTaste">Taste</button>
                    <button style="margin: 30px;" @click="sortByTexture">Texture</button>
                    <button style="margin: 30px;" @click="sortByVisualPresentation">VisualPresentation</button>
                </div>                
                <div style="margin: 30px;">
                    <label>Your Postiton:</label>
                    <input class="v" type="text" v-model="postionLat" placeholder="postionLat" id="postionLat">
                    <input class="v" type="text" v-model="postionLon" placeholder="postionLon" id="postionLon">
                    <button style="margin: 30px;" @click="searchNearBy">Find NearBy</button>
                </div>
                <template v-for="item in burgerStoreList">
                    <burgerStore :burgerStore="item" :key="item.id"></burgerStore>
                </template>
            </main>

            <div class="more" v-show="hasNextPage">
                <div class="more-btn" @click="loadMore">More</div>
            </div>
        </div>
    </div>
</template>

<script>
    import Banner from '@/components/banner'
    import Feature from '@/components/feature'
    import sectionTitle from '@/components/section-title'
    import Post from '@/components/post'
    import BurgerStore from '@/components/burgerStore'
    import SmallIco from '@/components/small-ico'
    import Quote from '@/components/quote'
    import {fetchFocus, fetchList, fetchAllBurgerStores, fetchAllBurgerStoresWithSort,
            fetchNearByBurgerStores} from '../api'

    export default {
        name: 'Home',
        props: ['cate', 'words'],
        data() {
            return {
                features: [],
                postList: [],
                burgerStoreList:[],
                currPage: 1,
                hasNextPage: false,
                isDesc: false,
                postionLat: '',
                postionLon: ''
            }
        },
        components: {
            Banner,
            Feature,
            sectionTitle,
            Post,
            SmallIco,
            Quote,
            BurgerStore
        },
        computed: {
            searchWords() {
                return this.$route.params.words
            },
            category() {
                return this.$route.params.cate
            },
            hideSlogan() {
                return this.category || this.searchWords
            },
            notice() {
                return this.$store.getters.notice
            }
        },
        methods: {
            fetchBurgerStores(){
                fetchAllBurgerStores().then(res =>{
                    this.burgerStoreList = res.data.items || []
                    this.currPage = 1
                    this.hasNextPage = true                    
                }).catch(err=>{
                    console.log(err);
                })
            },
            fetchFocus() {
                fetchFocus().then(res => {
                    this.features = res.data || []
                }).catch(err => {
                    console.log(err)
                })
            },
            fetchList() {
                fetchList().then(res => {
                    this.postList = res.data.items || []
                    this.currPage = res.data.page
                    this.hasNextPage = res.data.hasNextPage
                }).catch(err => {
                    console.log(err)
                })
            },
            loadMore() {
                fetchList({page:this.currPage+1}).then(res => {
                    this.postList = this.postList.concat(res.data.items || [])
                    this.currPage = res.data.page
                    this.hasNextPage = res.data.hasNextPage
                })
            },
            sortByTaste(){
                let order = this.isDesc? 'desc': ''
                let params = {Sorting:'averageTasteScore '+order}
                fetchAllBurgerStoresWithSort(params).then(res =>{
                    this.burgerStoreList = res.data.items || []
                    console.log("averageTasteScore"+this.burgerStoreList);
                    this.currPage = 1
                    this.hasNextPage = true
                }).catch(err=>{
                    console.log(err);
                })

                this.isDesc = !this.isDesc;
            },
            sortByTexture(){
                let order = this.isDesc? 'desc': ''
                let params = {Sorting:'averageTextureScore '+order}
                fetchAllBurgerStoresWithSort(params).then(res =>{
                    this.burgerStoreList = res.data.items || []
                    console.log("averageTasteScore"+this.burgerStoreList);
                    this.currPage = 1
                    this.hasNextPage = true
                }).catch(err=>{
                    console.log(err);
                })
                this.isDesc = !this.isDesc;
            },
            sortByVisualPresentation(){
                let order = this.isDesc? 'desc': ''
                let params = {Sorting:'averageVisualPresentationScore '+order}
                fetchAllBurgerStoresWithSort(params).then(res =>{
                    this.burgerStoreList = res.data.items || []
                    console.log("averageTasteScore"+this.burgerStoreList);
                    this.currPage = 1
                    this.hasNextPage = true
                }).catch(err=>{
                    console.log(err);
                })
                this.isDesc = !this.isDesc;
            },
            searchNearBy(){
                let params = {positionLat:this.postionLat,
                               postitionLon: this.postionLon};
                fetchNearByBurgerStores(params).then(res =>{
                    this.burgerStoreList = res.data || []
                    this.currPage = 1
                    this.hasNextPage = true
                }).catch(err=>{
                    console.log(err);
                })
            }
        },
        mounted() {
            this.fetchBurgerStores();
            this.fetchFocus();
            this.fetchList();
        }
    }
</script>
<style scoped lang="less">

    .site-content {
        .notify {
            margin: 60px 0;
            border-radius: 3px;
            & > div {
                padding: 20px;
            }
        }


        .search-result {
            padding: 15px 20px;
            text-align: center;
            font-size: 20px;
            font-weight: 400;
            border: 1px dashed #ddd;
            color: #828282;
        }
    }

    .top-feature {
        width: 100%;
        height: auto;
        margin-top: 30px;

        .feature-content {
            margin-top: 10px;
            display: flex;
            justify-content: space-between;
            position: relative;

            .feature-item {
                width: 32.9%;
            }
        }
    }

    .site-main {
        padding-top: 80px;

        &.search {
            padding-top: 0;
        }
    }

    .more{
        margin: 50px 0;
        .more-btn{
            width: 100px;
            height: 40px;
            line-height: 40px;
            text-align: center;
            color: #ADADAD;
            border: 1px solid #ADADAD;
            border-radius: 20px;
            margin: 0 auto;
            cursor: pointer;
            &:hover{
                color: #8fd0cc;
                border: 1px dashed #8fd0cc;
            }
        }
    }

    /******/
    @media (max-width: 800px) {
        .top-feature {
            display: none;
        }

        .site-main {
            padding-top: 40px;
        }

        .site-content {
            .notify {
                margin: 30px 0 0 0;
            }

            .search-result {
                margin-bottom: 20px;
                font-size: 16px;
            }
        }
    }

    /******/
</style>
