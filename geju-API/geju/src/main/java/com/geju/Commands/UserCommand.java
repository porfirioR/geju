package com.geju.Commands;

import java.sql.Date;

public class UserCommand {

	private String Name;
	private Date RegisterDate;
	private String Email;
	
	public String getName() {
		return Name;
	}

	public void setName(String name) {
		Name = name;
	}

	public Date getRegisterDate() {
		return RegisterDate;
	}

	public void setRegisterDate(Date registerDate) {
		RegisterDate = registerDate;
	}

	public String getEmail() {
		return Email;
	}

	public void setEmail(String email) {
		Email = email;
	}
	
}
