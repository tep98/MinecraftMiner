mergeInto(LibraryManager.library, {

  AddMoney : function(){

    ysdk.adv.showRewardedVideo({
      callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
        },
        onRewarded: () => {
          console.log('Rewarded!');
        },
        onClose: () => {
          console.log('Video ad closed.');
          myGameInstance.SendMessage('MoneyManager', 'AddBonusMoney');
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
      }
    })
  },

  AddPickaxeLevel : function(){

    ysdk.adv.showRewardedVideo({
      callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
        },
        onRewarded: () => {
          console.log('Rewarded!');
        },
        onClose: () => {
          console.log('Video ad closed.');
          myGameInstance.SendMessage('UpgradePickaxe', 'AddLevels');
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
      }
    })
  },

  AddLuckyLevel : function(){

    ysdk.adv.showRewardedVideo({
      callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
        },
        onRewarded: () => {
          console.log('Rewarded!');
          myGameInstance.SendMessage('LevelManager', 'GetBonus');
        },
        onClose: () => {
          console.log('Video ad closed.');
          myGameInstance.SendMessage('LevelManager', 'GetBonus');
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
      }
    })
  },

  StartAdBanner : function(){

    ysdk.adv.showFullscreenAdv({
      callbacks: {
        onClose: function(wasShown) {
          myGameInstance.SendMessage('Yandex', 'OffPause');
          // some action after close
        },
        onError: function(error) {
          myGameInstance.SendMessage('Yandex', 'OffPause');
          // some action on error
        }
      }
    })
  },

  GetLang : function() {
    var lang = ysdk.environment.i18n.lang;
    var bufferSize = lengthBytesUTF8(lang) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(lang, buffer, bufferSize);
    return buffer;
  },

  StartGame : function(){
    initPlayer();
  },

  SaveExtern: function(date){
      try {
          var dateString = UTF8ToString(date);
          console.log(dateString);
          var myobj = JSON.parse(dateString);
          // Предполагается, что player имеет метод setData
          player.setData(myobj);
          // Добавьте вызов функции сохранения внутри SaveExtern
          myGameInstance.SendMessage('Progress', 'SetPlayerInfo', dateString);
      } catch (error) {
          console.error("Error in SaveExtern:", error);
      }
  },



//   LoadExtern : function(){
//     initPlayer().then(() => {
//         return player.getData();
//     }).then(_date => {
//         const myJSON = JSON.stringify(_date);
//         console.log("Loaded data from external source: " + myJSON);
//         myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
//     });
// },

  LoadExtern : function(){
      initPlayer();
      player.getData().then(_date => {
          const myJSON = JSON.stringify(_date);
          console.log("Loaded data from external source: " + myJSON);
          myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
      }).catch(error => {
          console.error("Error loading data from external source:", error);
      });
},



});