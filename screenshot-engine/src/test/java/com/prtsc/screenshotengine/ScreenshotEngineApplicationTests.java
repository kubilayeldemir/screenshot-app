package com.prtsc.screenshotengine;

import org.junit.jupiter.api.Test;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.springframework.boot.test.context.SpringBootTest;

@SpringBootTest
class ScreenshotEngineApplicationTests {

	@Test
	void contextLoads() {
	}
	@Test
	void driverTest(){
//		System.setProperty("webdriver.chrome.driver", "C:\\Projects\\screenshot-app\\screenshot-engine\\chromedriver.exe");
		WebDriver webDriver = new ChromeDriver();
		webDriver.get("https://www.youtube.com");
		webDriver.quit();
	}
}
