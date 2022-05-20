
import 'package:flutter/material.dart';
import 'package:messaging/services/user_service.dart';

import '../models/models/user_model.dart';
import '../screens/chats/chats_screen.dart';
import 'action_result_generic (1).dart';


class SplashPage extends StatelessWidget {
 SplashPage({Key? key}) : super(key: key);
TextEditingController login = TextEditingController();
TextEditingController password = TextEditingController();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        mainAxisAlignment: MainAxisAlignment.spaceAround,
        children: [
          const SizedBox(height: 25),
          const Text(
            'Let\'s plant with us',
            style: TextStyle(
              fontSize: 22.0,
              letterSpacing: 1.8,
              fontWeight: FontWeight.w900,
            ),
          ),
          const SizedBox(height: 5),
          const Text(
            'Bring nature home',
            style: TextStyle(
              color: Color(0xFF9C9C9C),
              fontSize: 16,
              letterSpacing: 1.8,
              fontWeight: FontWeight.w600,
            ),
          ),
          SizedBox(
            child: TextField(
              controller: login,
              decoration: InputDecoration(hintText: "Введите логин") ,
            ),
          ),
          SizedBox(
            child: TextField(
              controller: password,
              decoration: InputDecoration(hintText: "Введите пароль") ,
            ),
          ),
          const SizedBox(height: 25),
          GestureDetector(
            onTap: () async {
              ActionResult<UserInfoModel> user = await UserService.authUserApi(login.text, password.text);
              if(user.data == null)
              return;
              Navigator.push(
                  context,
                  MaterialPageRoute(
                      builder: (builder) => ChatsScreen()));
            },
            child: Container(
              padding: const EdgeInsets.symmetric(
                horizontal: 80.0,
                vertical: 12.0,
              ),
              decoration: BoxDecoration(
                color: Color(0xFF2FA849),
                borderRadius: BorderRadius.circular(10.0),
              ),
              child: const Text(
                'Sign In',
                style: TextStyle(
                  color: Color(0xFFFFFFFF),
                  fontSize: 16,
                  fontWeight: FontWeight.w600,
                ),
              ),
            ),
          ),
          TextButton(
            onPressed: () {},
            child: Text(
              'Create an account',
              style: TextStyle(
                color: Color(0xFF071B0C).withOpacity(0.7),
                fontSize: 16,
                letterSpacing: 1,
                fontWeight: FontWeight.w600,
              ),
            ),
          ),
          TextButton(
            onPressed: () {},
            child: Text(
              'Forgot Password?',
              style: TextStyle(
                color: Color(0xFF071B0C).withOpacity(0.4),
                letterSpacing: 1,
                fontWeight: FontWeight.w600,
              ),
            ),
          ),
        ],
      ),
    );
  }
}