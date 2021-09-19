package com.prtsc.screenshotengine;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import ru.yandex.qatools.ashot.AShot;
import ru.yandex.qatools.ashot.shooting.ShootingStrategies;

import javax.imageio.ImageIO;
import java.io.File;

@SpringBootApplication
public class ScreenshotEngineApplication {

	public static void main(String[] args) {
		SpringApplication.run(ScreenshotEngineApplication.class, args).close();
		System.setProperty("webdriver.chrome.driver", "C:\\Projects\\screenshot-app\\screenshot-engine\\chromedriver.exe");

		WebDriver webDriver = new ChromeDriver();
		webDriver.get("https://www.youtube.com/watch?v=V4NJo2Mfvrc");
		var screenshot = new AShot()
				.shootingStrategy(ShootingStrategies.viewportPasting(100))
				.takeScreenshot(webDriver);
		try{
			ImageIO.write(screenshot.getImage(),"PNG",new File("./Screenshots/elementScreenshot.png"));
		}
		catch (Exception e){
			System.out.println(e);
		}
		webDriver.quit();

	}

}
