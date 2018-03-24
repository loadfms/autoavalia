var store = require('store')
var expirePlugin = require('store/plugins/expire')
store.addPlugin(expirePlugin)

const STORE_NAME = 'AutoAvaliaData'

export default class Storage {

	static setStore(_object, _storeName = STORE_NAME) {
		var expiration = new Date().getTime() + 7200000
		store.set(_storeName, _object, expiration)
	}

	static setKeyValue(_key, _value, _storeName = STORE_NAME) {
		if (_key) {
			let _obj = getStore(_storeName) || {};
			_obj[_key] = _value;
			setStore(_obj, _storeName)
		}
	}

	static getStore(_storeName = STORE_NAME) {
		return store.get(_storeName)
	}

	static clearStore(_storeName = STORE_NAME) {
		store.set(_storeName, null)
	}

	static deleteStore(_key, _storeName = STORE_NAME) {
		if (_key) {
			var _obj = getStore(_storeName)
			if (_obj) {
				delete _obj[_key]
				setStore(_obj, _storeName)
			}
		}
	}
}