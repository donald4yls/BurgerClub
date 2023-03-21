import request from '@/utils/request'

export function fetchAllBurgerStores(){
    return request({
        url:'api/app/burger-store',
        method: 'get',
        params: {}
    })
}

export function fetchAllBurgerStoresWithSort(params){
    return request({
        url:'api/app/burger-store',
        method: 'get',
        params: params
    })
}

export function fetchNearByBurgerStores(params){
    return request({
        url:'api/app/burger-store/near-by-burger-stores',
        method: 'get',
        params: params
    })
}


export function fetchList(params) {
    return request({
        url: '/post/list',
        method: 'get',
        params: params
    })
}

export function fetchFocus() {
    return request({
        url: '/focus/list',
        method: 'get',
        params: {}
    })
}

export function fetchCategory() {
    return request({
        url: '/category',
        method: 'get',
        params: {}
    })
}

export function fetchFriend() {
    return request({
        url: '/friend',
        method: 'get',
        params: {}
    })
}

export function fetchSocial() {
    return request({
        url: '/social',
        method: 'get',
        params: {}
    });
}

export function fetchSiteInfo() {
    return request({
        url: '/site',
        method: 'get',
        params: {}
    })
}

export function fetchComment() {
    return request({
        url: '/comment',
        method: 'get',
        params: {}
    })
}
