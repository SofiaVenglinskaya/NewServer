

import 'main.dart';

class LocalStorageService {
  static void setUserData({String? currentUserPassword, required String currentUserLogin}) {
    if (currentUserLogin != null) {
      MyApp.storage.write(key: "CurrentUserNickname", value: currentUserLogin);
    }
    if (currentUserPassword != null) {
      MyApp.storage.write(key: "CurrentUserPassword", value: currentUserPassword);
    }
  }

  static void clearUserData() {
    MyApp.storage.write(key: "CurrentUserNickname", value: null);
    MyApp.storage.write(key: "CurrentUserPassword", value: null);
  }
}