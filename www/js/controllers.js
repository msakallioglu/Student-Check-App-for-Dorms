angular.module('starter.controllers', [])

  .controller('DashCtrl', function ($scope, $http, $state, $rootScope) {

 
    $scope.Yoneticigirisyap = function (TC, sifre) {
      $http.get("http://localhost:49758/api/Yonetici/YoneticiGirisYap?TC=" + TC + "&sifre=" + sifre)
        .then(function (response) {
          if (response.data == 0) {
            alert("Yönetici Bulunamadi");
          }
          else {

            alert("Giris Basarili Hosgeldiniz ID = " + response.data);
            $rootScope.id = response.data;
            $state.go("tab.chats")
          }

        });
    }

    $scope.Ogrencigirisyap = function (oTC, osifre) {
      $http.get("http://localhost:49758/api/Ogrenci/OgrenciGirisYap?TC=" + oTC + "&sifre=" + osifre)
        .then(function (response) {
          if (response.data == 0) {
            alert("Ogrenci Bulunamadi");
          }
          else {

            alert("Giris Basarili Hosgeldiniz ID = " + response.data);
            $rootScope.id = response.data;
            $state.go("tab.account")
          }
        });
    }

  })
  .controller('ogrenciizinleriCtrl', function ($scope, $http,$rootScope) {
    $scope.$on('$ionicView.enter', function (e) {
    $http.get("http://localhost:49758/api/Ogrencizin/TumOgrenciIzinleriniGetir")
        .then(function (response) {
          $scope.ogrenciz = response.data;
        });
  

    $scope.onay = function (izinid, sayi) {
      $http.get("http://localhost:49758/api/Ogrencizin/IzinOnayla?IzinID=" + izinid + "&onaydurumu=" + sayi + "&yoneticiID=" + $rootScope.id)
        .then(function (response) {
          $scope.ogrenciz = response.data;
        });
    }
    $scope.onaylama = function (izinid, sayi) {
      $http.get("http://localhost:49758/api/Ogrencizin/IzinOnayla?IzinID=" + izinid + "&onaydurumu=" + sayi + "&yoneticiID=" + $rootScope.id)
        .then(function (response) {
          $scope.ogrenciz = response.data;
        });
    }

  });
  })


  .controller('yenigorevekleCtrl', function ($scope,$http) {

    $http.get("http://localhost:49758/api/Personel/TumPersonelleriGetir")
      .then(function (response) {
        $scope.personel = response.data;
      });

    $scope.personelara = function (isim) {
      $http.get("http://localhost:49758/api/Personel/PersonelAra?kelime=" + isim)
        .then(function (response) {
            $scope.personel = response.data;
      
        });
    }

    $scope.gorev = { };
    $scope.yenigorevekle= function (veri) {
      $http.post("http://localhost:49758/api/PersonelGorev/GorevEkle",veri)
        .then(function (response) {
          if (response.data == true) {
            alert("Gorev Ekleme Basarili");
            $scope.gorev = { };
          }
          else {
            alert("Gorev Ekleme Basarisiz");
            $scope.gorev = { };

          }
        });
    }


  })
  .controller('yenipersonelekleCtrl', function ($scope, $http) {

    $scope.personel = { };

    $scope.yenipersonelekle = function (veri) {
      $http.post("http://localhost:49758/api/Personel/PersonelEkle", veri)
        .then(function (response) {
          if (response.data == true) {
            alert("Personel Ekleme Basarili");
            $scope.personel = { };
          }
          else
          {
            alert("Personel Ekleme Basarisiz");
            $scope.personel = { };
          }
            
        });
    }

  })

  .controller('girisCtrl', function ($scope) {
  })

  .controller('izinistegiCtrl', function ($scope,$http) {

    $scope.izin = { };

    $scope.izinekle = function (veri) {
      $http.post("http://localhost:49758/api/Ogrencizin/IzinEkle", veri)
        .then(function (response) {
          if (response.data == true)
          {
            alert("Izin Ekleme Basarili");
            $scope.izin = { };
          }
          else
          {
            
            alert("Izin Ekleme Basarisiz");
            $scope.izin = { };
          }         
        });
    }
  })

  .controller('personelekleCtrl', function ($scope, $rootScope, $http) {

    $scope.$on('$ionicView.enter', function (e) {
      $http.get("http://localhost:49758/api/PersonelGorev/TumGorevleriGetir")
        .then(function (response) {
          $scope.gorevler = response.data;
        });
   
    });

    $scope.gorevsil = function (gorevid) {
      $http.get("http://localhost:49758/api/PersonelGorev/GorevSil?GorevID=" + gorevid)
        .then(function (response) {
          $scope.gorevler = response.data;
        });
    }
  })
 

  .controller('ChatsCtrl', function ($scope, Chats, $rootScope, $http) {
    $scope.$on('$ionicView.enter', function (e) {
      //alert($rootScope.id);
      $http.get("http://localhost:49758/api/Yonetici/IdyeGoreYoneticiGetir?YoneticiID=" + $rootScope.id)
      .then(function (response) {
        $scope.Yonetici = response.data;
      });
    });

  })

  .controller('ogrencilisteleCtrl', function ($scope, $http) {
    $scope.$on('$ionicView.enter', function (e) {
      $http.get("http://localhost:49758/api/Ogrenci/TumOgrencileriGetir")
        .then(function (response) {
          $scope.ogrenciler = response.data;
        })
    });
    $scope.ogrencisil = function (ogrenciid) {
      $http.get("http://localhost:49758/api/Ogrenci/OgrenciSilIDgore?OgrenciID=" + ogrenciid)
        .then(function (response) {
          $scope.ogrenciler = response.data;
        });
    }

    $scope.ogrenciara = function (isim) {
      $http.get("http://localhost:49758/api/Ogrenci/OgrenciAraIsmeGore?kelime=" + isim)
        .then(function (response) {
          $scope.ogrenciler = response.data;
        });
    }

  })

  .controller('ogrenciekleCtrl', function ($scope, $http, $state, $rootScope) {
    $scope.yeniogrenci = { };

    $scope.ogrenciekle = function (veri) {
      $http.post("http://localhost:49758/api/Ogrenci/OgrenciEkle",veri)
        .then(function (response) {
          if (response.data == true) {

            alert("Ogrenci Kaydi Basarili");
            $scope.yeniogrenci = { };
          }
          else {

            alert("Ogrenci Kaydi Basarisiz");
            $scope.yeniogrenci = { };
          }
            
        });

    }
  })

  .controller('ChatDetailCtrl', function ($scope, $stateParams, $http) {

    $scope.ogrenciguncelle = function (OgrenciID, OdaNumarasi, Telefon, Mail, AcilDurumTelefon, VeliAdSoyad) {
      $http.get("http://localhost:49758/api/Ogrenci/OgrenciGuncelle?OgrenciID=" + OgrenciID + "&Mail=" + Mail + "&Telefon=" + Telefon + "&AcilDurumTelefon=" + AcilDurumTelefon + "&VeliAdSoyad=" + VeliAdSoyad + "&OdaNumarasi=" + OdaNumarasi)
        .then(function (response) {
          $scope.ogrenci = response.data;

        });

    };

    $http.get("http://localhost:49758/api/Ogrenci/IdyeGoreOgrenciGetir?OgrenciID=" + $stateParams.ogrenciID)
      .then(function (response) {
        $scope.ogrenci = response.data;
      });
    
  })

  .controller('AccountCtrl', function ($scope, $http, $state, $rootScope) {
    $scope.$on('$ionicView.enter', function (e) {
      $http.get("http://localhost:49758/api/Ogrencizin/IdyeGoreOgrenciizinGetir?OgrenciID=" + $rootScope.id)
      .then(function (response) {
        $scope.ogrenciizin = response.data;

      });
    });
    $scope.iziniptal = function (id) {
      $http.get("http://localhost:49758/api/Ogrencizin/OgrenciIzinIptal?IzinID=" + id)
        .then(function (response) {
          $scope.ogrenciizin = response.data;
        });
    }
   
  })
