package com.geju.Api.Controllers.Admin;

import java.sql.Date;
import java.util.ArrayList;
import java.util.List;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.geju.Commands.UserCommand;

@RestController
@RequestMapping("/user")
public class UserController {
	@GetMapping
	List<UserCommand> GetAllUser() {
		UserCommand user = new UserCommand();
		user.setName("hola");
		user.setEmail("aaa@aaa");
		user.setRegisterDate(new Date(0));
		List<UserCommand> list = new ArrayList<UserCommand>();
		list.add(user);
		return list;
	}
	@GetMapping("{id}")
	UserCommand GetUser(@PathVariable Long id) {
		UserCommand user = new UserCommand();
		user.setName("hola");
		user.setEmail("aaa@aaa");
		user.setRegisterDate(new Date(0));
		return user;
	}

}
