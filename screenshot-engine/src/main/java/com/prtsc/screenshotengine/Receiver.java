package com.prtsc.screenshotengine;

import com.google.gson.Gson;
import org.springframework.stereotype.Component;
import java.nio.charset.StandardCharsets;
import java.util.logging.Level;
import java.util.logging.Logger;

@Component
public class Receiver {
    Logger logger = Logger.getLogger(String.valueOf(Receiver.class));

    public void receiveMessage(byte[] message) {
        String stringMessage = new String(message, StandardCharsets.UTF_8);
        Gson gson = new Gson();
        var request = gson.fromJson(stringMessage, ScreenshotRequestModel.class);
        ScreenshotEngine.takeScreenshot(request.getWebsiteURL());
        logger.log(Level.INFO ,() -> "New Screenshot captured: " + stringMessage);
    }
}
